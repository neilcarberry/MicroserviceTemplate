using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddGenderCommand : IRequest
    {
        public GenderDTO Gender { get; set; }
    }
}
