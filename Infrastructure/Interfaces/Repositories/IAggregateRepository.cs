using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAggregateRepository
    {
        IAuctionRepository AuctionRepository { get; }
    }
}
