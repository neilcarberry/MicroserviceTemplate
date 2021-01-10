using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddDescriptionCommand : IRequest
    {
        public DescriptionDTO Description { get; set; }
    }
}
