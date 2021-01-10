using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteDescriptionCommandHandler : BaseHandler<DeleteDescriptionCommand, Unit>
    {

        public DeleteDescriptionCommandHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(DeleteDescriptionCommand request, CancellationToken cancellationToken)
        {
            var description = UnitOfWork.Description.SingleOrDefaultById(request.Id);
            UnitOfWork.Description.Remove(Mapper.Map<Descriptions>(description));


            return Unit.Task;
        }
    }
}
