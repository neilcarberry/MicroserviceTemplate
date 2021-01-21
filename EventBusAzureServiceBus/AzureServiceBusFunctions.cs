using EventBus.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventBusAzureServiceBus
{
    public class MessageRecievedEventArgs : EventArgs
    {
        public Func<string, string, Task<bool>> Callback { get; set; }
        public Message Message { get; set; }
    }
    public class AzureServiceBusConnection : IPersistentConnection
    {
        private readonly QueueClient QueueConnection;
        public bool IsConnected { get; set; }
        public ILogger<AzureServiceBusConnection> Logger { get; }
        public event EventHandler ReceivedMessageEvent;
        public MessageRecievedEventArgs MessageRecieved = new MessageRecievedEventArgs();
        public AzureServiceBusConnection(AzureServiceBusConnectionDetails azureServiceBusConnectionDetails, ILogger<AzureServiceBusConnection> logger, string exchange, string queueName)
        {
            Logger = logger;
            QueueConnection = new QueueClient(azureServiceBusConnectionDetails.ConnectionString, queueName);

        }

        private void ReceivedMessageHandler(object sender, EventArgs e)
        {
            MessageRecievedEventArgs messageRecievedEventArgs = (MessageRecievedEventArgs)e;
            Message message = messageRecievedEventArgs.Message;
            var eventBody = Encoding.ASCII.GetString(message.Body);
            var eventName = message.Label;
            var result = messageRecievedEventArgs.Callback(eventName, eventBody).Result;
            if (result)
            {
                QueueConnection.CompleteAsync(message.SystemProperties.LockToken);
            }
        }

        private Task ProcessMessage(Message message, CancellationToken token)
        {
            lock (MessageRecieved)
            {
                MessageRecieved.Message = message;
                ReceivedMessageEvent.Invoke(this, MessageRecieved);
            }
            return Task.CompletedTask;
        }

        public void CreateConsumerChannel(Func<string, string, Task<bool>> callback)
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };
            MessageRecieved.Callback = callback;
            ReceivedMessageEvent = new EventHandler(ReceivedMessageHandler);
            QueueConnection.RegisterMessageHandler(ProcessMessage, messageHandlerOptions);
        }


        public void Publish(string eventName, byte[] body)
        {
            Logger.Log(LogLevel.Information, $"Publishing {eventName}");
            var message = new Message(body);
            message.Label = eventName;
            QueueConnection.SendAsync(message);
            Logger.Log(LogLevel.Information, $"Published {eventName}");
        }

        public void RemoveRoutingKey(string eventName)
        {
            throw new NotImplementedException();
        }

        public bool TryConnect()
        {
            return true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void AddRoutingKey(string eventName)
        {
        }

        public void CreateChannel()
        {
        }
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Error in message: {arg.Exception}");
            return Task.CompletedTask;
        }
    }
}
