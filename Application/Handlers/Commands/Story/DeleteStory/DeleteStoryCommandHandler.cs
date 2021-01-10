using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteStoryCommandHandler : BaseHandler<DeleteStoryCommand, Unit>
    {

        public DeleteStoryCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator) 
        {
        }
        public override Task<Unit> HandleEx(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var story = UnitOfWork.Description.SingleOrDefaultById(request.Id);
            UnitOfWork.Story.Remove(Mapper.Map<Storys>(story));
            

            return Unit.Task;
        }
    }
}
