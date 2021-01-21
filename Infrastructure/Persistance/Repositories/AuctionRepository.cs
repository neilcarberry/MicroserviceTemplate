using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Repositories
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {
        public AuctionRepository(IDatabaseContext context) : base(context)
        {

        }
        public Auction GetAuction(string id)
        {
            return new Auction() { AuctioneerId = 1, Id = 1, SellerID = 2, Vehicle = 3 };
        }
        public List<Auction> GetAllAuctions()
        {
            Console.WriteLine("GETTING DATA FROM DATABASE");

            return new List<Auction>()
            {
                new Auction() {
                    AuctioneerId = 1, Id = 1, SellerID = 2, Vehicle = 3
                },
                new Auction() {
                    AuctioneerId = 1, Id = 1, SellerID = 2, Vehicle = 3
                }
            };
        }
        public void AddAuction(Auction auction)
        {
            Console.WriteLine("WROTE SALE TO DATABSE");
        }
    }
}