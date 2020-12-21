using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetAbilityReferenceQuery : IRequest<AbilityReferenceDTO>
    {
        public int Id { get; set; }
    }
}
