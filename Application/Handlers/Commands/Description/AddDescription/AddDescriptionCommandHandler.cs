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
    public class AddDescriptionCommandHandler : BaseHandler<AddDescriptionCommand,Unit>
    {
        public AddDescriptionCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddDescriptionCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Description.Add(Mapper.Map<Descriptions>(request.Description));
            

            return Unit.Task;
        }
    }
}
