using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteRaceLanguageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
