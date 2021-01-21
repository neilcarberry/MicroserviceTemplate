using Domain.AutoMapper;
using EventBus.Events;
using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Events.NewAuction
{
    public class NewAuctionEvent : IntegrationEvent, INotification
    {
        public string AuctionName { get; set; }
    }
}
