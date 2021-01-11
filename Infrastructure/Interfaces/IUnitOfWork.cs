using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {     
        IAuctionRepository AbilityModifier { get; }
        public List<IRepository> Repositories { get; }
        IRepository<T> GetRepository<T>() where T : class;
        void AbortTransaction();
        void CompleteTransaction();
        void BeginTransaction();
    }
}
