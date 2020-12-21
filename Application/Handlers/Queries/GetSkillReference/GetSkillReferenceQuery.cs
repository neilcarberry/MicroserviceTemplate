using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetSkillReferenceQuery : IRequest<SkillReferenceDTO>
    {
        public int Id { get; set; }
    }
}
