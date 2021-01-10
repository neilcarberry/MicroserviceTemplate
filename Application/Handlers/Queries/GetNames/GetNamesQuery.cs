using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetNamesQuery : IRequest<NamesDTO>
    {
        public int Id { get; set; }
    }
}
