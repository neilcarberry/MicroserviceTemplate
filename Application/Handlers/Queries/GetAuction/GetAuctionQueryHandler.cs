using Application.Abstractions;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAuctionQueryHandler : BaseHandler<GetAuctionQuery, AuctionDTO>
    {
        public override async Task<AuctionDTO> HandleEx(GetAuctionQuery request, CancellationToken cancellationToken)
        {
            AuctionDTO asd = new AuctionDTO() { AuctioneerId = 1, Id = 1, SellerID = 22 };
            var auctions = UnitOfWork.AuctionRepository.SingleOrDefaultById(request.Id);
            return Mapper.Map<AuctionDTO>(auctions); 
        }
    }
}
