using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyAuctionCommand : IRequest
    {
        public AuctionDTO AbilityModifier { get; set; }
    }
}
