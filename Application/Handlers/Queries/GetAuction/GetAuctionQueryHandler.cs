using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAuctionQueryHandler : BaseHandler<GetAuctionQuery, AuctionDTO>
    {

        public GetAuctionQueryHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }
        public override async Task<AuctionDTO> HandleEx(GetAuctionQuery request, CancellationToken cancellationToken)
        {
            var auctions = UnitOfWork.AuctionRepository.SingleOrDefaultById(request.Id);
            return Mapper.Map<AuctionDTO>(auctions); 
        }
    }
}
