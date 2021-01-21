using Application.Abstractions;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Events.NewAuction
{
    public class NewAuctionEventHandler : BaseEventHandler<NewAuctionEvent>
    {
        public NewAuctionEventHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {

        }
        public override Task HandleEx(NewAuctionEvent @event)
        {
            Console.WriteLine($"Received new auction: {@event.AuctionName} at {@event.CreationDate}");

            UnitOfWork.AuctionRepository.AddAuction(Mapper.Map<Auction>(@event));

            return Task.CompletedTask;
        }
    }
}
