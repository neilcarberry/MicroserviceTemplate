using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddNamesCommandHandler : BaseHandler<AddNamesCommand, Unit>
    {

        public AddNamesCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddNamesCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Names.Add(Mapper.Map<Names>(request.Names));
            

            return Unit.Task;

        }
    }
}
