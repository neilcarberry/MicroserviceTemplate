using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetRaceQuery : IRequest<BaseDetailsDTO>
    {
        public int Id { get; set; }
    }
}
