using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddRaceLanguageCommand : IRequest
    {
        public RaceLanguageDTO RaceLanguage { get; set; }
    }
}
