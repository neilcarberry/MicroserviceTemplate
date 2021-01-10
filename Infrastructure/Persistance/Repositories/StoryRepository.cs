using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class StoryRepository : Repository<Storys>, IStoryRepository
    {
        public StoryRepository(IDatabaseContext context) :base(context)
        {

        }
    }
}
