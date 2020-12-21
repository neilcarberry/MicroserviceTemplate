using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteAbilityReferenceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
