using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAbilityReferenceQueryHandler : IRequestHandler<GetAbilityReferenceQuery, AbilityReferenceDTO>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public GetAbilityReferenceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<AbilityReferenceDTO> Handle(GetAbilityReferenceQuery request, CancellationToken cancellationToken)
        {
            var AbilityReference = UnitOfWork.AbilityReference.SingleOrDefaultById(request.Id);
            return Mapper.Map<AbilityReferenceDTO>(AbilityReference);
        }
    }
}
