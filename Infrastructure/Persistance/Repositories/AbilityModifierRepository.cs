using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class AbilityModifierRepository : Repository<AbilityModifier>, IAbilityModifierRepository
    {
        public AbilityModifierRepository(IDatabaseContext context) : base(context)
        {

        }

        public void test()
        {
            throw new System.NotImplementedException();
        }
    }
}
