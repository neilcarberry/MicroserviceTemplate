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
    public class GetRacesQueryHandler : BaseHandler<GetRacesQuery, List<BaseDetailsDTO>>
    {

        public GetRacesQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<BaseDetailsDTO>> HandleEx(GetRacesQuery request, CancellationToken cancellationToken)
        {
            var baseDetails = await UnitOfWork.BaseDetail.GetAllAsync();

            var baseDetailsDTO = Mapper.Map<List<BaseDetailsDTO>>(baseDetails).ToList();

            return baseDetailsDTO;
        }
    }
}
