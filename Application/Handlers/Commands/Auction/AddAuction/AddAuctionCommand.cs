using Domain.Models;
using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddAuctionCommand : IRequest
    {
        public AuctionDTO AbilityModifier { get; set; }
    }
}
