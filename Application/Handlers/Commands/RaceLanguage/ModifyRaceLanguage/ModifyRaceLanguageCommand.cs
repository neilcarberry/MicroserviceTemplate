using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyRaceLanguageCommand : IRequest
    {
        public RaceLanguageDTO RaceLanguage { get; set; }
    }
}
