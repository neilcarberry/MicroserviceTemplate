using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class BaseDetailsRepository : Repository<BaseDetails>, IBaseDetailsRepository
    {
        public BaseDetailsRepository(IDatabaseContext context) : base(context)
        {
        }

    }
}
