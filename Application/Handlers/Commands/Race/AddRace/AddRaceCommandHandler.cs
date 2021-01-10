using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddRaceCommandHandler : BaseHandler<AddRaceCommand, Unit>
    {
        public AddRaceCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddRaceCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.BaseDetail.Add(Mapper.Map<BaseDetails>(request.BaseDetails));
            

            return Unit.Task;
        }
    }
}
