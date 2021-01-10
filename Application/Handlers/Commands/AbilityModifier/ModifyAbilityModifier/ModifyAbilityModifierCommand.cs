using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyAbilityModifierCommand : IRequest
    {
        public AbilityModifierDTO AbilityModifier { get; set; }
    }
}
