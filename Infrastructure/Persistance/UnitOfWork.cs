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
        public IAuctionRepository AuctionRepository { get; }

        public UnitOfWork(IDatabaseContext context, IAggregateRepository aggregateRepository)
        {
            _context = context;
            AuctionRepository = aggregateRepository.AuctionRepository;
            BeginTransaction();
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
