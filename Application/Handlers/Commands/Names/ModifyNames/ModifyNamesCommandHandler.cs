using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Handlers.Commands
{
    public class ModifyNamesCommandHandler : BaseHandler<ModifyNamesCommand, Unit>
    {
        public ModifyNamesCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyNamesCommand request, CancellationToken cancellationToken)
        {
            var Names = UnitOfWork.Names.SingleOrDefaultById(request.Names.Id);
            Names = Mapper.Map<Names>(request.Names);

            UnitOfWork.Names.Update(Names);
            

            return Unit.Task;
        }
    }
}
