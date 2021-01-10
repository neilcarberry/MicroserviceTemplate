using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAbilityModifierQueryHandler : BaseHandler2<GetAbilityModifierQuery, AbilityModifierDTO>
    {

        public GetAbilityModifierQueryHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }
        public override async Task<AbilityModifierDTO> HandleEx(GetAbilityModifierQuery request, CancellationToken cancellationToken)
        {
            DescriptionDTO s;
            //var AbilityMod = UnitOfWork.AbilityModifier.SingleOrDefaultById(request.Id);
            AbilityModifierDTO bob = new AbilityModifierDTO() { AbilityId = 1, Modifier = 1, RaceId = 2, Id = 1 };
            bob.SetUpMapper(Mapper);
            bob.MapToEntity();
            return default;
        }
    }
}
