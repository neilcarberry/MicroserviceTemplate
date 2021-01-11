using EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EventBusAzureServiceBus.Extensions
{
    public static class AzureServiceBusExtensions
    {
        public static void RegisterConnection(this IServiceCollection serviceCollection, AzureServiceBusConnectionDetails connectionDetails, string exchangeName, string queueName)
        {
            serviceCollection.AddSingleton<IPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                return new DefaultRabbitMQPersistentConnection(connectionDetails, logger, exchangeName, queueName);
            });
        }
    }
}
