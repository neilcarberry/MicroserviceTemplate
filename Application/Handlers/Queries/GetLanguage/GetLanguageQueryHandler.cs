using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, LanguageDTO>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public GetLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<LanguageDTO> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            var Language = UnitOfWork.Languages.SingleOrDefaultById(request.Id);
            return Mapper.Map<LanguageDTO>(Language);
        }
    }
}
