using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddSkillReferenceCommand : IRequest
    {
        public SkillReferenceDTO SkillReference { get; set; }
    }
}
