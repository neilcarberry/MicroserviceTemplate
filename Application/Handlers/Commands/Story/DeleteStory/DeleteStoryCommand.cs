using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteStoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
