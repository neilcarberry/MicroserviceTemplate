using EventBus.Interfaces;
using EventBus_Framework.Exceptions;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class DefaultRabbitMQPersistentConnection : IPersistentConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<DefaultRabbitMQPersistentConnection> _logger;
        private IConnection _connection;
        private IModel _channel;
        private bool _disposed;
        private readonly string _exchangeName;
        private readonly string _queueName;

        private object sync_root = new object();

        private const string dead_letter_exchange = "dead-letter-exchange";
        private const string dead_letter_queue = "dead-letter-queue";
        public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;

        public DefaultRabbitMQPersistentConnection(ConnectionDetails connectionDetails,
            ILogger<DefaultRabbitMQPersistentConnection> logger, string exchangeName, string queueName)
        {
            _connectionFactory = CreateFactory(connectionDetails);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _exchangeName = exchangeName;
            _queueName = queueName;

            TryConnect();
            CreateChannel();
            SetupDeadLetterQueue();
            SetupExchange();
            SetupQueue();
        }
        public IConnectionFactory CreateFactory(ConnectionDetails connectionDetails)
        {
            var factory = new ConnectionFactory
            {
                HostName = connectionDetails.EventBusConnection,
                DispatchConsumersAsync = true,
                UserName = connectionDetails.EventBusUserName,
                Password = connectionDetails.EventBusPassword,
                Port = connectionDetails.EventBusPort
            };
            return factory;
        }
        public void CreateChannel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
            }
            if (_channel == null)
            {
                _channel = _connection.CreateModel();
            }
        }
        public void SetupDeadLetterQueue()
        {
            _channel.ExchangeDeclare(dead_letter_exchange, "fanout", durable: true);
            _channel.QueueDeclare(queue: dead_letter_queue,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
            _channel.QueueBind(dead_letter_queue, dead_letter_exchange, "");
        }
        public void SetupExchange()
        {
            _channel.ExchangeDeclare(exchange: _exchangeName, type: "direct", durable: true);

        }
        public void SetupQueue()
        {
            if (!String.IsNullOrEmpty(_queueName))
            {
                _channel.QueueDeclare(queue: _queueName,
                               durable: true,
                               exclusive: false,
                               autoDelete: false,
                               arguments: new ConcurrentDictionary<string, object>(new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("x-dead-letter-exchange", dead_letter_exchange) }));
            }
        }

        public void AddRoutingKey(string routingKey)
        {
            if (_channel == null)
            {
                _channel = _connection.CreateModel();
            }

            _channel.QueueBind(queue: _queueName,
                 exchange: _exchangeName,
                 routingKey: routingKey);
        }
        public void RemoveRoutingKey(string routingKey)
        {
            if (_channel == null)
            {
                _channel = _connection.CreateModel();
            }

            _channel.QueueUnbind(queue: _queueName,
                 exchange: _exchangeName,
                 routingKey: routingKey);
        }
        public void Publish(string eventName, byte[] body)
        {
            try
            {
                _channel.BasicPublish(exchange: _exchangeName,
                     routingKey: eventName,
                     basicProperties: new BasicProperties { DeliveryMode = 2 },
                     body: body);
            }
            catch (BrokerUnreachableException ex)
            {
                throw new CantReachBrokerException(ex);
            }
        }

        public void CreateConsumerChannel(Func<string, string, Task<bool>> callback)
        {
            if (!IsConnected)
            {
                TryConnect();
            }

            _channel = _connection.CreateModel();
           
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {              
                var message = Encoding.UTF8.GetString(ea.Body);
                var result = await callback(ea.RoutingKey, message);

                if (result)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                else
                {
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
            };

            _channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);

            _channel.CallbackException += (sender, ea) =>
            {
                _channel.Dispose();
                CreateConsumerChannel(callback);
            };

        }
        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }
        public bool TryConnect()
        {
            _logger.LogInformation("RabbitMQ Client is trying to connect");

            lock (sync_root)
            {
                _connection = _connectionFactory.CreateConnection();

                if (IsConnected)
                {
                    _connection.ConnectionShutdown += OnConnectionShutdown;
                    _connection.CallbackException += OnCallbackException;
                    _connection.ConnectionBlocked += OnConnectionBlocked;

                    _logger.LogInformation("RabbitMQ Client acquired a persistent connection to '{HostName}' and is subscribed to failure events", _connection.Endpoint.HostName);
                    
                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");

                    return false;
                }
            }
        }
        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed) return;

            _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");

            TryConnect();
        }

        private void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (_disposed) return;

            _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

            TryConnect();
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed) return;

            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

            TryConnect();
        }
    }
}