using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteDescriptionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
