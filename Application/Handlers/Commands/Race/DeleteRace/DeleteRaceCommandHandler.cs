using Application.Abstractions;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteRaceCommandHandler : BaseHandler<DeleteRaceCommand, Unit>
    {
        public DeleteRaceCommandHandler(ICoreAggregator coreAggregator) :base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(DeleteRaceCommand request, CancellationToken cancellationToken)
        {
            var deleteRace = UnitOfWork.BaseDetail.SingleOrDefaultById(request.BaseDetailsID);
            UnitOfWork.BaseDetail.Remove(deleteRace);
            
            return Unit.Task;
        }
    }
}
