using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries
{
    public class GetDescriptionQuery : IRequest<List<DescriptionDTO>>
    {
        public int Id { get; set; }
    }
}
