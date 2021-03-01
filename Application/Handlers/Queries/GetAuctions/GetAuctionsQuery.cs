using Application.Interfaces;
using Domain.Models;
using Infrastructure.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries
{
    public class GetAuctionsQuery : IRequest<List<AuctionDTO>>
    {
        public int Id { get; set; }
    }
}
