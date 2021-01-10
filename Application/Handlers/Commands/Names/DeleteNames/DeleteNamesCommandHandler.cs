using Application.Abstractions;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteNamesCommandHandler : BaseHandler<DeleteNamesCommand, Unit>
    {

        public DeleteNamesCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(DeleteNamesCommand request, CancellationToken cancellationToken)
        {
            var Names = UnitOfWork.Names.SingleOrDefaultById(request.Id);
            UnitOfWork.Names.Remove(Names);


            return Unit.Task;
        }
    }
}
