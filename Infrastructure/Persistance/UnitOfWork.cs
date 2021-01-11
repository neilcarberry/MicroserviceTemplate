using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDatabaseContext _context;
        public List<IRepository> Repositories { get; }
        public IAuctionRepository AbilityModifier { get; }

        public UnitOfWork(IDatabaseContext context, IAggregateRepository aggregateRepository)
        {
            _context = context;
            AbilityModifier = aggregateRepository.AbilityModifier;
            Repositories = new List<IRepository>();
            Repositories.Add(aggregateRepository.AbilityModifier);
            BeginTransaction();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return (IRepository<T>)Repositories.First(x => x.GetType().GetInterfaces().Where(x => x.FullName.Contains(typeof(T).Name)).Count() > 0);

        }
        public void AbortTransaction()
        {
            _context.AbortTransaction();
        }

        public void CompleteTransaction()
        {
            _context.CompleteTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void BeginTransaction()
        {
            // _context.BeginTransaction();
        }
    }
}
