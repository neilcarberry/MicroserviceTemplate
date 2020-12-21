using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<LanguageDTO>>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;
        public GetLanguagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<List<LanguageDTO>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {
            var Languages = await UnitOfWork.Languages.GetAllAsync();

            var LanguageDTO = Mapper.Map<List<LanguageDTO>>(Languages).ToList();

            return LanguageDTO;
        }
    }
}
