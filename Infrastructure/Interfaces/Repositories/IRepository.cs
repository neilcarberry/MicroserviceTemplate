using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        TEntity SingleOrDefaultById(int id);

        IEnumerable<TEntity> GetAll();
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        int AddReturnId(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveById(int id);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Save(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        Task<TEntity> SingleOrDefaultByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);
        Task RemoveByIdAsync(int id);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
