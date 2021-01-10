using Application.Abstractions;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteSkillBonusCommandHandler : BaseHandler<DeleteSkillBonusCommand, Unit>
    {

        public DeleteSkillBonusCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(DeleteSkillBonusCommand request, CancellationToken cancellationToken)
        {
            var SkillBonus = UnitOfWork.SkillBonus.SingleOrDefaultById(request.Id);
            UnitOfWork.SkillBonus.Remove(SkillBonus);
            

            return Unit.Task;
        }
    }
}
