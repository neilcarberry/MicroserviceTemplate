using EventBus.Events;

namespace EventBus.Interfaces
{
    public interface IEventBus
    {
        void Subscribe(IIntegrationEventHandler handler);
        void Unsubscribe(IIntegrationEventHandler handler);
        void Publish(IntegrationEvent message);
        void StartConsuming();
    }
}