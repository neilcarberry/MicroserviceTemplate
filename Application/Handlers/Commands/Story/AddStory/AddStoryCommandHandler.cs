using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddStoryCommandHandler : BaseHandler<AddStoryCommand, Unit>
    {
        public AddStoryCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddStoryCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Story.Add(Mapper.Map<Storys>(request.Story));
            

            return Unit.Task;
        }
    }
}
