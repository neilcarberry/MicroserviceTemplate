using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteRaceCommand : IRequest
    {
        public int BaseDetailsID { get; set; }
    }
}
