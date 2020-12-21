using System.Threading.Tasks;

namespace EventBus.Interfaces
{
    public interface IIntegrationEventHandler<in IIntegrationEvent> : IIntegrationEventHandler        
    {
        Task<bool> Handle(IIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}