using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddRaceCommand : IRequest
    {
        public BaseDetailsDTO BaseDetails { get; set; }
    }
}
