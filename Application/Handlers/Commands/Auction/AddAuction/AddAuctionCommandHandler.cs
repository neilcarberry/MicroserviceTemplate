using Application.Abstractions;
using Application.Handlers.Events.NewAuction;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddAuctionCommandHandler : BaseHandler<AddAuctionCommand, Unit>
    {
        public AddAuctionCommandHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(AddAuctionCommand request, CancellationToken cancellationToken)
        {
            Logger.Log("test test", "Other stuff");
            //((IAbilityModifierRepository)UnitOfWork.GetRepository<AbilityModifier>()).test();
            Mediator.Publish(new NewAuctionEvent() { AuctionName = "Wilsons Sale" });
            return Unit.Task;
        }
    }
}
