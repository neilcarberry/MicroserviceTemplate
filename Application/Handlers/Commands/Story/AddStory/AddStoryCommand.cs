using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class AddStoryCommand : IRequest
    {
        public StoryDTO Story { get; set; }
    }
}
