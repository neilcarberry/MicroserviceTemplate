using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Handlers.Commands
{
    public class ModifySkillBonusCommandHandler : BaseHandler<ModifySkillBonusCommand, Unit>
    {

        public ModifySkillBonusCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifySkillBonusCommand request, CancellationToken cancellationToken)
        {
            var SkillBonus = UnitOfWork.SkillBonus.SingleOrDefaultById(request.SkillBonus.Id);
            SkillBonus = Mapper.Map<RaceSkillBonuses>(request.SkillBonus);

            UnitOfWork.SkillBonus.Update(SkillBonus);
            

            return Unit.Task;
        }
    }
}
