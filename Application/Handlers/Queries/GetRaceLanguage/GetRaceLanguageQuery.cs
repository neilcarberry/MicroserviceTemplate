using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetRaceLanguageQuery : IRequest<RaceLanguageDTO>
    {
        public int Id { get; set; }
    }
}
