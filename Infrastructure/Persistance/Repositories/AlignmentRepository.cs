using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class AlignmentRepository : Repository<Alignment>, IAlignmentRepository
    {
        public AlignmentRepository(IDatabaseContext context) : base(context)
        {
        }
    }
}
