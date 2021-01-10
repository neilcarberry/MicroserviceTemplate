using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class NamesRepository : Repository<Names>, INamesRepository
    {
        public NamesRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
