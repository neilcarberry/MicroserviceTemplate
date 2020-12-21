using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class SkillReferenceRepository : Repository<SkillReference>, ISkillReferenceRepository
    {
        public SkillReferenceRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
