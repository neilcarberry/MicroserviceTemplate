using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetGenderQuery : IRequest<GenderDTO>
    {
        public int Id { get; set; }
    }
}
