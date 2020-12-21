using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddLanguageCommand : IRequest
    {
        public LanguageDTO Language { get; set; }
    }
}
