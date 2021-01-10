using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyNamesCommand : IRequest
    {
        public NamesDTO Names { get; set; }
    }
}
