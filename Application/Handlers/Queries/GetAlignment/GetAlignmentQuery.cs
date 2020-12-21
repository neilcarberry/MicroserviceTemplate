using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetAlignmentQuery : IRequest<AlignmentDTO>
    {
        public int Id { get; set; }
    }
}
