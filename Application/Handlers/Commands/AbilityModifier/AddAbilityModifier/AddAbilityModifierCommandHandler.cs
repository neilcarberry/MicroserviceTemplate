using Application.Abstractions;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddAbilityModifierCommandHandler : BaseHandler<AddAbilityModifierCommand, Unit>
    {
        public AddAbilityModifierCommandHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(AddAbilityModifierCommand request, CancellationToken cancellationToken)
        {
            Logger.LogError("test test", "Other stuff");
            //((IAbilityModifierRepository)UnitOfWork.GetRepository<AbilityModifier>()).test();
                        
            return Unit.Task;

        }
    }
}
