using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries
{
    public class GetRacesQuery : IRequest<List<BaseDetailsDTO>>
    {
    }
}
