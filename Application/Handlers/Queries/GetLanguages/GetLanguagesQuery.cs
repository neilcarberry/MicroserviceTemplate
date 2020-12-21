using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetLanguagesQuery : IRequest<List<LanguageDTO>>
    {
    }
}
