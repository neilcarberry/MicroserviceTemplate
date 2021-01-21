using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAuctionsQueryHandler : BaseHandler<GetAuctionsQuery, List<AuctionDTO>>
    {

        public GetAuctionsQueryHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }

        public override async Task<List<AuctionDTO>> HandleEx(GetAuctionsQuery request, CancellationToken cancellationToken)
        {
            var auctions = await UnitOfWork.AuctionRepository.GetAllAsync();
            return Mapper.Map<List<AuctionDTO>>(auctions);
        }
    }
}
