using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class AbilityReferenceRepository : Repository<AbilityReference>, IAbilityReferenceRepository
    {

        public AbilityReferenceRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
