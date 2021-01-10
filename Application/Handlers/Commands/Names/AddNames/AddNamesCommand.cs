using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddNamesCommand : IRequest
    {
        public NamesDTO Names { get; set; }
    }
}
