using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyStoryCommandHandler : BaseHandler<ModifyStoryCommand, Unit>
    {

        public ModifyStoryCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyStoryCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Story.Update(Mapper.Map<Storys>(request.Story));
            

            return Unit.Task;
        }
    }
}
