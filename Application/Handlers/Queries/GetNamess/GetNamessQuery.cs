using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Queries
{
    public class GetNamessQuery : IRequest<List<NamesDTO>>
    {
    }
}
