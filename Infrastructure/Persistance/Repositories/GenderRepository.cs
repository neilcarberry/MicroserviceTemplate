using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class GenderRepository : Repository<Genders>, IGenderRepository
    {
        public GenderRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
