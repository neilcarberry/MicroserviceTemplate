using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetRaceQueryHandler : BaseHandler<GetRaceQuery, BaseDetailsDTO>
    {

        public GetRaceQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<BaseDetailsDTO> HandleEx(GetRaceQuery request, CancellationToken cancellationToken)
        {
            var baseDetails = UnitOfWork.BaseDetail.SingleOrDefaultById(request.Id);
            return Mapper.Map<BaseDetailsDTO>(baseDetails);
        }
    }
}
