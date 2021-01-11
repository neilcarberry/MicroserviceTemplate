using Application.Abstractions;
using AutoMapper;
using Domain.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class AuctionDTO : BaseModel<Auction>, IMap<Auction> 
    {
        public int Id { get; set; }
        public int Modifier { get; set; }
        public int AbilityId { get; set; }       
    }
}