using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyRaceCommandHandler : BaseHandler<ModifyRaceCommand, Unit>
    {

        public ModifyRaceCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyRaceCommand request, CancellationToken cancellationToken)
        {
            var ModifiedBase = UnitOfWork.BaseDetail.SingleOrDefaultById(request.BaseDetails.Id);
            ModifiedBase = Mapper.Map<BaseDetails>(request.BaseDetails);

            UnitOfWork.BaseDetail.Update(ModifiedBase);
            

            return Unit.Task;
        }
    }
}
