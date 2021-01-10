using Application.Abstractions;
using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyAbilityModifierCommandHandler : BaseHandler<ModifyAbilityModifierCommand,Unit>
    {

        public ModifyAbilityModifierCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyAbilityModifierCommand request, CancellationToken cancellationToken)
        {
            var abilityMod = UnitOfWork.AbilityModifier.SingleOrDefaultById(request.AbilityModifier.Id);
            abilityMod = Mapper.Map<AbilityModifier>(request.AbilityModifier);
            UnitOfWork.AbilityModifier.Update(abilityMod);

            return Unit.Task;
        }
    }
}
