using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IDatabaseContext Context;

        public Repository(IDatabaseContext context)
        {
            Context = context;

            if (Context.Connection.State == ConnectionState.Closed)
            {
                if (Context.ConnectionString == string.Empty) 
                {
                    throw new Exception("Connections string non existatnt");
                }
                Console.WriteLine("Connecting to database");
                //Context.Connection.Open();
            }
        }

        public TEntity SingleOrDefaultById(int id)
        {
            return Context.SingleOrDefaultById<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Query<TEntity>().ToEnumerable();
        }


        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Query<TEntity>().Where(predicate).SingleOrDefault();
        }

        public void Add(TEntity entity)
        {
            Context.Insert(entity);
        }
        public int AddReturnId(TEntity entity)
        {
            return (int)Context.Insert(entity); ;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.InsertBulk(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Delete<TEntity>(entity);
        }
        public void RemoveById(int id)
        {
            Context.Delete<TEntity>(id);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            Context.Save(entity);
        }
        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            List<UpdateBatch<TEntity>> updateEntities = new List<UpdateBatch<TEntity>>();
            foreach (var item in entities)
            {
                UpdateBatch<TEntity> entity = new UpdateBatch<TEntity>() { Poco = item };
                updateEntities.Add(entity);
            }

            Context.UpdateBatch(updateEntities);
        }
        public async Task<TEntity> SingleOrDefaultByIdAsync(int id)
        {
            return await Context.SingleOrDefaultByIdAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.QueryAsync<TEntity>().ToEnumerable();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.QueryAsync<TEntity>().Where(predicate).SingleOrDefault();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.InsertAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.InsertBatchAsync(entities);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Context.DeleteAsync(entity);
        }
        public async Task RemoveByIdAsync(int id)
        {
            await Context.DeleteAsync(id);
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
