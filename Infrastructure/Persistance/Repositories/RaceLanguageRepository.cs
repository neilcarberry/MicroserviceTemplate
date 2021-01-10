using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class RaceLanguageRepository : Repository<RaceLanguage>, IRaceLanguageRepository
    {
        public RaceLanguageRepository(IDatabaseContext context) : base (context)
        {

        }
    }
}
