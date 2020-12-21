using Domain.Models;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetLanguageQuery : IRequest<LanguageDTO>
    {
        public int Id { get; set; }
    }
}
