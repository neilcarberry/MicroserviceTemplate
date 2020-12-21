using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetSkillReferenceQueryHandler : IRequestHandler<GetSkillReferenceQuery, SkillReferenceDTO>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public GetSkillReferenceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<SkillReferenceDTO> Handle(GetSkillReferenceQuery request, CancellationToken cancellationToken)
        {
            var SkillReference = UnitOfWork.SkillReference.SingleOrDefaultById(request.Id);
            return Mapper.Map<SkillReferenceDTO>(SkillReference);
        }
    }
}
