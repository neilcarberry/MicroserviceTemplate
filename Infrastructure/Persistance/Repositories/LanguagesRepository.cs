using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class LanguagesRepository : Repository<Languages>, ILanguagesRepository
    {
        public LanguagesRepository(IDatabaseContext context) : base(context)
        {
        }
    }
}
