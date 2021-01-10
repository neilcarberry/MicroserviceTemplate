using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class DescriptionRepository : Repository<Descriptions>, IDescriptionRepository
    {
        public DescriptionRepository(IDatabaseContext context) : base(context)
        {

        }
    }
}
