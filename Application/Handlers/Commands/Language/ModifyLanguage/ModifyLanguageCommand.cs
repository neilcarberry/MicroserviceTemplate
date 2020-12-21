using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyLanguageCommand : IRequest
    {
        public LanguageDTO Language { get; set; }
    }
}
