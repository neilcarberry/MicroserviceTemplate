using EventBus;
using EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventBusRabbitMQ.Extensions
{
    public static class RabbitMQServiceExtension
    {
        public static void RegisterConnection(this IServiceCollection serviceCollection, ConnectionDetails connectionDetails, string exchangeName, string queueName)
        {
            serviceCollection.AddSingleton<IPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                return new DefaultRabbitMQPersistentConnection(connectionDetails, logger, exchangeName, queueName);
            });
        }
    }
}