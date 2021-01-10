using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetSkillBonusQueryHandler : BaseHandler<GetSkillBonusQuery, SkillBonusDTO>
    {

        public GetSkillBonusQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<SkillBonusDTO> HandleEx(GetSkillBonusQuery request, CancellationToken cancellationToken)
        {
            var SkillBonus = UnitOfWork.SkillBonus.SingleOrDefaultById(request.Id);
            return Mapper.Map<SkillBonusDTO>(SkillBonus);
        }
    }
}
