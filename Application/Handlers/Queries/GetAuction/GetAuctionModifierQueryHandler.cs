using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAuctionModifierQueryHandler : BaseHandler2<GetAuctionModifierQuery, AuctionDTO>
    {

        public GetAuctionModifierQueryHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }
        public override async Task<AuctionDTO> HandleEx(GetAuctionModifierQuery request, CancellationToken cancellationToken)
        {
            DescriptionDTO s;
            //var AbilityMod = UnitOfWork.AbilityModifier.SingleOrDefaultById(request.Id);
            AuctionDTO bob = new AuctionDTO() { AbilityId = 1, Modifier = 1, RaceId = 2, Id = 1 };
            bob.SetUpMapper(Mapper);
            bob.MapToEntity();
            return default;
        }
    }
}
