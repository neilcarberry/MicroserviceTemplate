using EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EventBus.Extensions
{
    public static class EvenbtBusServiceExtension
    {
        public static void RegisterEventBus(this IServiceCollection serviceCollection, int retry)
        {
            serviceCollection.AddSingleton<IEventBus, EventBusService>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IPersistentConnection>();
                var logger = sp.GetRequiredService<ILogger<EventBusService>>();
                return new EventBusService(rabbitMQPersistentConnection, logger, retry);
            });
        }
       
        public static void ConfigureEventBus(this IServiceProvider serviceProvider)
        {
            var events = serviceProvider.GetServices<IIntegrationEventHandler>();

            var eventBus = serviceProvider.GetRequiredService<IEventBus>();
            foreach (var item in events)
            {
                eventBus.Subscribe(item);
            }
            eventBus.StartConsuming();
        }
    }
}