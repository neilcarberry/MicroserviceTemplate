using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Commands
{
    public class ModifyStoryCommand : IRequest
    {
        public Storys Story { get; set; }
    }
}
