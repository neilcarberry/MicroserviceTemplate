using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddAbilityReferenceCommand : IRequest
    {
        public AbilityReferenceDTO AbilityReference { get; set; }
    }
}
