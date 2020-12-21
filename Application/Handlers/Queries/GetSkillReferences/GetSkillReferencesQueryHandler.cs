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
    public class GetSkillReferencesQueryHandler : IRequestHandler<GetSkillReferencesQuery, List<SkillReferenceDTO>>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;
        public GetSkillReferencesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<List<SkillReferenceDTO>> Handle(GetSkillReferencesQuery request, CancellationToken cancellationToken)
        {
            var SkillReferences = await UnitOfWork.SkillReference.GetAllAsync();

            var SkillReferenceDTO = Mapper.Map<List<SkillReferenceDTO>>(SkillReferences).ToList();

            return SkillReferenceDTO;
        }
    }
}
