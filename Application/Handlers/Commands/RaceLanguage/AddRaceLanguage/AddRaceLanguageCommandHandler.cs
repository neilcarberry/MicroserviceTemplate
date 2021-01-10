using Application.Abstractions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddRaceLanguageCommandHandler : BaseHandler<AddRaceLanguageCommand, Unit>
    {

        public AddRaceLanguageCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(AddRaceLanguageCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.RaceLanguage.Add(Mapper.Map<RaceLanguage>(request.RaceLanguage));
            

            return Unit.Task;

        }
    }
}
