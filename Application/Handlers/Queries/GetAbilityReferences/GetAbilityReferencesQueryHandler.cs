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
    public class GetAbilityReferencesQueryHandler : IRequestHandler<GetAbilityReferencesQuery, List<AbilityReferenceDTO>>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;
        public GetAbilityReferencesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<List<AbilityReferenceDTO>> Handle(GetAbilityReferencesQuery request, CancellationToken cancellationToken)
        {
            var AbilityReferences = await UnitOfWork.AbilityReference.GetAllAsync();

            var AbilityReferenceDTO = Mapper.Map<List<AbilityReferenceDTO>>(AbilityReferences).ToList();

            return AbilityReferenceDTO;
        }
    }
}
