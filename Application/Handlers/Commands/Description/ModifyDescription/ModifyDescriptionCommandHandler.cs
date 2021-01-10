using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyDescriptionCommandHandler : BaseHandler<ModifyDescriptionCommand, Unit>
    {

        public ModifyDescriptionCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyDescriptionCommand request, CancellationToken cancellationToken)
        {
            var description = UnitOfWork.Description.SingleOrDefaultById(request.Description.Id);
            description = Mapper.Map<Descriptions>(request.Description);
            UnitOfWork.Description.Update(description);
            

            return Unit.Task;
        }
    }
}
