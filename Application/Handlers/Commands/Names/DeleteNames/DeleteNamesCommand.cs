using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteNamesCommand : IRequest
    {
        public int Id { get; set; }
    }
}
