using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries
{
    public class GetStoryQuery : IRequest<List<StoryDTO>>
    {
        public int Id { get; set; }
    }
}
