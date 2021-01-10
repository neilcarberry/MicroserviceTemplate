using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using AutoMapper;
using EventBus.Events;
using EventBus.Interfaces;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;



public static class EpicStringHelper
{
    public static string ToString(string stringy)
    {
        List<char> charholder = new List<char>();
        foreach (char item in stringy)
        {
            charholder.Add(item);
        }
        return charholder.Aggregate(new StringBuilder(), (current, next) => current.Append(current.Length == 0 ? "" : ", ").Append(next)).ToString();
    }

}

namespace Application.Abstractions
{
    public abstract class BaseEventHandler<IEvent> : IIntegrationEventHandler<IEvent> where IEvent : IntegrationEvent
    {
        protected readonly ILogger<IIntegrationEventHandler<IEvent>> Logger;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected List<IntegrationEvent> eventsToPublish = new List<IntegrationEvent>();
        protected IMediator Mediator;
        protected readonly string AppName = Assembly.GetCallingAssembly().FullName;

        public BaseEventHandler(ICoreAggregator coreAggregator)
        {
            Logger = coreAggregator.Logger.CreateLogger<IIntegrationEventHandler<IEvent>>();
            UnitOfWork = coreAggregator.UnitOfWork ?? throw new ArgumentNullException(nameof(coreAggregator.UnitOfWork));
            Mapper = coreAggregator.Mapper ?? throw new ArgumentNullException(nameof(coreAggregator.Mapper));
            Mediator = coreAggregator.Mediator ?? throw new ArgumentNullException(nameof(coreAggregator.Mediator));
        }

        public List<IntegrationEvent> GetPublishedEvents()
        {
            return eventsToPublish;
        }

        public async Task PublishNewIntegrationEvents()
        {
            foreach (var eventToPublish in eventsToPublish)
            {
                try
                {
                    Logger.LogInformation($"Publishing integration event {eventToPublish}");
                    await Mediator.Publish(eventToPublish);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"----- Error during publishing of new integration event: {eventToPublish.ToString()} {ex.Message}");
                }
            }
        }

        public async Task<bool> Handle(IEvent @event)
        {
            try
            {
                Logger.LogInformation(
                    $"----- Handling integration event: {@event.Id} at: Dispatch Service - {@event}");
                await HandleEx(@event);
                UnitOfWork.CompleteTransaction();
                Task.Run(() => PublishNewIntegrationEvents());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"----- Error during integration event: {ex.Message}", "");
                UnitOfWork.AbortTransaction();
            }
            return true;
        }

        public abstract Task HandleEx(IEvent @event);


    }
}