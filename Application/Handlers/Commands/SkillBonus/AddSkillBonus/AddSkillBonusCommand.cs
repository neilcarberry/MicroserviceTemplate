using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddSkillBonusCommand : IRequest
    {
        public SkillBonusDTO SkillBonus { get; set; }
    }
}
