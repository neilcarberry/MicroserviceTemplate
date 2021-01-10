using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddSkillBonusCommandHandler : BaseHandler<AddSkillBonusCommand, Unit>
    {

        public AddSkillBonusCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddSkillBonusCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.SkillBonus.Add(Mapper.Map<RaceSkillBonuses>(request.SkillBonus));
            

            return Unit.Task;

        }
    }
}
