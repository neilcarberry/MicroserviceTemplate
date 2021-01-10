using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class SkillBonusesRepository : Repository<RaceSkillBonuses>, ISkillBonusesRepository
    {
        public SkillBonusesRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
