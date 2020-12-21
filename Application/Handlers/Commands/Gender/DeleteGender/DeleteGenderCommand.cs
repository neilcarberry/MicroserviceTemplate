using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteGenderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
