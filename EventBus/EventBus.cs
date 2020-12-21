using EventBus.Interfaces;
using EventBus.Events;
using EventBus_Framework.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class EventBusService : IEventBus, IDisposable
    {
        private readonly IPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusService> _logger;
        private readonly Dictionary<Type, IIntegrationEventHandler> _handlers = new Dictionary<Type, IIntegrationEventHandler>();
        private Policy _policy;
        public EventBusService(IPersistentConnection persistentConnection, ILogger<EventBusService> logger, int retryCount)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _policy = Policy.Handle<CantReachBrokerException>()
               .Or<SocketException>()
               .WaitAndRetry(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time, context) =>
               {
                   _logger.LogWarning(ex, $"{context["logmessage"]}$ after {time.TotalSeconds:n1}, {ex.Message}");
               });
        }

        public void Publish(IntegrationEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _policy.Execute((context) => _persistentConnection.TryConnect(), new Dictionary<string, object>()
                {
                    {
                        "logmessage",
                        "RabbitMQ Client could not connect "
                    }
                });
            }

            _persistentConnection.CreateChannel();
            var eventName = @event.GetType().Name;
            string message;
            if (@event.LegacyOut)
            {
                message = JsonConvert.SerializeObject(new LegacyOut(@event, eventName));
                eventName = "LegacyOutIntegrationEvent";
            }
            else
            {
                message = JsonConvert.SerializeObject(@event);
            }

            var body = Encoding.UTF8.GetBytes(message);

            _policy.Execute((context) => _persistentConnection.Publish(eventName, body), new Dictionary<string, object>()
            {
                {
                    "logmessage",
                    $"Could not publish event: {@event.Id} "
                }
            });
        }
        public void Subscribe(IIntegrationEventHandler handler)
        {
            var eventType = handler.GetType().BaseType.GetGenericArguments().First();
            if (!_handlers.ContainsKey(eventType))
            {
                if (!_persistentConnection.IsConnected)
                {
                    _policy.Execute((context) => _persistentConnection.TryConnect(), new Dictionary<string, object>()
                    {
                        {
                            "logmessage",
                            "RabbitMQ Client could not connect "
                        }
                    });
                }
                _persistentConnection.CreateChannel();
                _persistentConnection.AddRoutingKey(eventType.Name);

                _handlers.Add(eventType, handler);
            }
        }
        public void Unsubscribe(IIntegrationEventHandler handler)
        {
            var eventType = handler.GetType().BaseType.GetGenericArguments().First();
            if (_handlers.ContainsKey(eventType))
            {
                _handlers.Remove(eventType);
                if (!_persistentConnection.IsConnected)
                {
                    _policy.Execute((context) => _persistentConnection.TryConnect(), new Dictionary<string, object>()
                    {
                        {
                            "logmessage",
                            "RabbitMQ Client could not connect "
                        }
                    });
                }
                _persistentConnection.CreateChannel();
                _persistentConnection.RemoveRoutingKey(eventType.Name);
            }
        }
        public void Dispose()
        {
            _persistentConnection?.Dispose();
        }
        public void StartConsuming()
        {
            _persistentConnection.CreateConsumerChannel(TryProcessEvent);
        }
        private async Task<bool> TryProcessEvent(string eventName, string message)
        {
            try
            {
                var handlerTypePair = _handlers.First(x => x.Key.Name == eventName);
                if (handlerTypePair.Key != null)
                {
                    var integrationEvent = JsonConvert.DeserializeObject(message, handlerTypePair.Key);
                    var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(handlerTypePair.Key);

                    return await (Task<bool>)concreteType.GetMethod("Handle").Invoke(handlerTypePair.Value, new object[] { integrationEvent });
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}