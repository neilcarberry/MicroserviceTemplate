using Application.Interfaces;
using Application.Handlers.Events.NewAuction;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Handlers.Commands
{
    public class AddAuctionCommandHandler : BaseHandler<AddAuctionCommand, Unit>
    {
        public override Task<Unit> HandleEx(AddAuctionCommand request, CancellationToken cancellationToken)
        {
            //((IAbilityModifierRepository)UnitOfWork.GetRepository<AbilityModifier>()).test();
            Mediator.Publish(new NewAuctionEvent() { AuctionName = "Wilsons Sale" });
            return Unit.Task;
        }
    }
}
