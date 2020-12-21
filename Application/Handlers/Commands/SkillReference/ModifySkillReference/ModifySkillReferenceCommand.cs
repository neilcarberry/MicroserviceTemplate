using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifySkillReferenceCommand : IRequest
    {
        public SkillReferenceDTO SkillReference { get; set; }
    }
}
