using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteLanguageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
