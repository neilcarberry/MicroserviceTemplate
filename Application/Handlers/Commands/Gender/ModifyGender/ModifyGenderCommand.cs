using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyGenderCommand : IRequest
    {
        public GenderDTO Gender { get; set; }
    }
}
