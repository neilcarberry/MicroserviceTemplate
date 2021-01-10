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
    public class DeleteAbilityModifierCommandHandler : BaseHandler<DeleteAbilityModifierCommand, Unit>
    {
        public DeleteAbilityModifierCommandHandler(ICoreAggregator coreAggregator) :base(coreAggregator)
        {
        }

        public override Task<Unit> HandleEx(DeleteAbilityModifierCommand request, CancellationToken cancellationToken)
        {
            var abilityMod = UnitOfWork.AbilityModifier.SingleOrDefaultById(request.Id);
            UnitOfWork.AbilityModifier.Remove(Mapper.Map<AbilityModifier>(abilityMod));

            return Unit.Task;
        }

    }
}
