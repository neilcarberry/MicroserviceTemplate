using Application.Abstractions;
using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteAuctionCommandHandler : BaseHandler<DeleteAuctionCommand, Unit>
    {
        public DeleteAuctionCommandHandler(ICoreAggregator coreAggregator) :base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(DeleteAuctionCommand request, CancellationToken cancellationToken)
        {
            var abilityMod = UnitOfWork.AuctionRepository.SingleOrDefaultById(request.Id);
            UnitOfWork.AuctionRepository.Remove(Mapper.Map<Auction>(abilityMod));

            return Unit.Task;
        }

    }
}
