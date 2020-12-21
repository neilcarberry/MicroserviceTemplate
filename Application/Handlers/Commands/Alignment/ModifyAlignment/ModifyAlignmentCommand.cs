using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyAlignmentCommand : IRequest
    {
        public AlignmentDTO Alignment { get; set; }
    }
}
