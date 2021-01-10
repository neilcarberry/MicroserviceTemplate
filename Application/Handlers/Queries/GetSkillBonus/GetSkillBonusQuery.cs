using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetSkillBonusQuery : IRequest<SkillBonusDTO>
    {
        public int Id { get; set; }
    }
}
