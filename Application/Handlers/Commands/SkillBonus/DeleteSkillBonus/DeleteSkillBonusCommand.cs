using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteSkillBonusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
