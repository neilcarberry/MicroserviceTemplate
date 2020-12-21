using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteSkillReferenceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
