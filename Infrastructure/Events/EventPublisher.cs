using EventBus.Events;
using EventBus.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public class EventBusPublisher<T> : INotificationHandler<T> where T : IntegrationEvent, INotification
    {
        private readonly IEventBus _eventBus;
        public EventBusPublisher(IEventBus EventBus)
        {
            _eventBus = EventBus;
        }

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            _eventBus.Publish(notification);
        }
    }
}
