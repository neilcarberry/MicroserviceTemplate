using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyDescriptionCommand : IRequest
    {
        public DescriptionDTO Description { get; set; }
    }
}
