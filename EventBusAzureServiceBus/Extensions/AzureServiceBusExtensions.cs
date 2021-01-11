using EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EventBusAzureServiceBus.Extensions
{
    public static class AzureServiceBusExtensions
    {
        public static void RegisterConnection(this IServiceCollection serviceCollection, AzureServiceBusConnectionDetails connectionDetails, string exchangeName, string queueName)
        {
            serviceCollection.AddSingleton<IPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<AzureServiceBusConnection>>();
                return new AzureServiceBusConnection(connectionDetails, logger, exchangeName, queueName);
            });
        }
    }
}
