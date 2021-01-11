using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAuctionRepository : IRepository<Auction>
    {
        void test();
    }
}
