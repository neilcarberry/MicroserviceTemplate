using EventBus.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBusAzureServiceBus
{
    public class AzureServiceBusConnection : IPersistentConnection
    {
        private readonly QueueClient QueueConnection;
        public bool IsConnected { get; set; }
        public ILogger<AzureServiceBusConnection> Logger { get; }

        public AzureServiceBusConnection(AzureServiceBusConnectionDetails azureServiceBusConnectionDetails, ILogger<AzureServiceBusConnection> logger, string exchange, string queueName)
        {
            Logger = logger;
            QueueConnection = new QueueClient(azureServiceBusConnectionDetails.ConnectionString, queueName);
        }
        public void AddRoutingKey(string eventName)
        {
            throw new NotImplementedException();
        }

        public void CreateChannel()
        {
            throw new NotImplementedException();
        }

        public void CreateConsumerChannel(Func<string, string, Task<bool>> callback)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish(string eventName, byte[] body)
        {
            var message = new Message(body);
            message.Label = eventName;

            QueueConnection.SendAsync(message);
        }

        public void RemoveRoutingKey(string eventName)
        {
            throw new NotImplementedException();
        }

        public bool TryConnect()
        {
            throw new NotImplementedException();
        }
    }
}
