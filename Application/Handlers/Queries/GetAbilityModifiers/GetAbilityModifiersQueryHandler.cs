using Application.Abstractions;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAbilityModifiersQueryHandler : BaseHandler<GetAbilityModifiersQuery, List<AbilityModifierDTO>>
    {
        public GetAbilityModifiersQueryHandler(ICoreAggregator coreAggregator)
            : base(coreAggregator)
        {
        }

        public override Task<List<AbilityModifierDTO>> HandleEx(GetAbilityModifiersQuery request, CancellationToken cancellationToken)
        {
            //Mapper.ProjectTo<List<AbilityModifierDTO>>(UnitOfWork.AbilityModifier.GetAll().AsQueryable());
            return Task.FromResult(new List<AbilityModifierDTO>());
        }
    }
}
