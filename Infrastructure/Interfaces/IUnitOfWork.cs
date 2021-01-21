using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {     
        IAuctionRepository AuctionRepository { get; }
        void AbortTransaction();
        void CompleteTransaction();
        void BeginTransaction();
    }
}
