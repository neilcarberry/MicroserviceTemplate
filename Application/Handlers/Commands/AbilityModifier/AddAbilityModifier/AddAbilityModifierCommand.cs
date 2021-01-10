using Domain.Models;
using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddAbilityModifierCommand : IRequest
    {
        public AbilityModifierDTO AbilityModifier { get; set; }
    }
}
