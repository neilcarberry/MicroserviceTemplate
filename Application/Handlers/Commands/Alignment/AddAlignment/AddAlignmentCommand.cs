using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddAlignmentCommand : IRequest
    {
        public AlignmentDTO Alignment { get; set; }
    }
}
