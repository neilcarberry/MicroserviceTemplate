using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyRaceCommand : IRequest
    {
        public BaseDetailsDTO BaseDetails { get; set; }
    }
}
