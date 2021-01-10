using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifySkillBonusCommand : IRequest
    {
        public SkillBonusDTO SkillBonus { get; set; }
    }
}
