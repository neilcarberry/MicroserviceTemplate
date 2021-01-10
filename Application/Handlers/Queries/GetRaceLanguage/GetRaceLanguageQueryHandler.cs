using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetRaceLanguageQueryHandler : BaseHandler<GetRaceLanguageQuery, RaceLanguageDTO>
    {

        public GetRaceLanguageQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<RaceLanguageDTO> HandleEx(GetRaceLanguageQuery request, CancellationToken cancellationToken)
        {
            var RaceLanguage = UnitOfWork.RaceLanguage.SingleOrDefaultById(request.Id);
            return Mapper.Map<RaceLanguageDTO>(RaceLanguage);
        }
    }
}
