using Application.Abstractions;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteRaceLanguageCommandHandler : BaseHandler<DeleteRaceLanguageCommand, Unit>
    {

        public DeleteRaceLanguageCommandHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(DeleteRaceLanguageCommand request, CancellationToken cancellationToken)
        {
            var RaceLanguage = UnitOfWork.RaceLanguage.SingleOrDefaultById(request.Id);
            UnitOfWork.RaceLanguage.Remove(RaceLanguage);
            

            return Unit.Task;
        }
    }
}
