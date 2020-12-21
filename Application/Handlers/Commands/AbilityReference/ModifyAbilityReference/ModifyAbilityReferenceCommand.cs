using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyAbilityReferenceCommand : IRequest
    {
        public AbilityReferenceDTO AbilityReference { get; set; }
    }
}
