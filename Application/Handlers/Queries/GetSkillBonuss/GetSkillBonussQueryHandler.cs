using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetSkillBonussQueryHandler : BaseHandler<GetSkillBonussQuery, List<SkillBonusDTO>>
    {
        public GetSkillBonussQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<SkillBonusDTO>> HandleEx(GetSkillBonussQuery request, CancellationToken cancellationToken)
        {
            var SkillBonuss = await UnitOfWork.SkillBonus.GetAllAsync();

            var SkillBonusDTO = Mapper.Map<List<SkillBonusDTO>>(SkillBonuss).ToList();

            return SkillBonusDTO;
        }
    }
}
