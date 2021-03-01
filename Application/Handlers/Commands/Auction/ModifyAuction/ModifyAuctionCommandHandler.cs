using Application.Abstractions;
using Application.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyAuctionCommandHandler : BaseHandler<ModifyAuctionCommand,Unit>
    {
        public override Task<Unit> HandleEx(ModifyAuctionCommand request, CancellationToken cancellationToken)
        {
            var abilityMod = UnitOfWork.AuctionRepository.SingleOrDefaultById(request.AbilityModifier.Id);
            abilityMod = Mapper.Map<Auction>(request.AbilityModifier);
            UnitOfWork.AuctionRepository.Update(abilityMod);

            return Unit.Task;
        }
    }
}
