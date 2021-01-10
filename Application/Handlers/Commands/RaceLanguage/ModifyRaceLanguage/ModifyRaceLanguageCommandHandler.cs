using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Handlers.Commands
{
    public class ModifyRaceLanguageCommandHandler : BaseHandler<ModifyRaceLanguageCommand, Unit>
    {
        public ModifyRaceLanguageCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(ModifyRaceLanguageCommand request, CancellationToken cancellationToken)
        {
            var RaceLanguage = UnitOfWork.RaceLanguage.SingleOrDefaultById(request.RaceLanguage.Id);
            RaceLanguage = Mapper.Map<RaceLanguage>(request.RaceLanguage);

            UnitOfWork.RaceLanguage.Update(RaceLanguage);


            return Unit.Task;
        }
    }
}
