using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetAuctionQuery : IRequest<AuctionDTO>
    {
        public int Id { get; set; }
    }
}
