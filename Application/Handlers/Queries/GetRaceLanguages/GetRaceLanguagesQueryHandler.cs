using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetRaceLanguagesQueryHandler : BaseHandler<GetRaceLanguagesQuery, List<RaceLanguageDTO>>
    {
        public GetRaceLanguagesQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<RaceLanguageDTO>> HandleEx(GetRaceLanguagesQuery request, CancellationToken cancellationToken)
        {
            var RaceLanguages = await UnitOfWork.RaceLanguage.GetAllAsync();

            var RaceLanguageDTO = Mapper.Map<List<RaceLanguageDTO>>(RaceLanguages).ToList();

            return RaceLanguageDTO;
        }
    }
}
