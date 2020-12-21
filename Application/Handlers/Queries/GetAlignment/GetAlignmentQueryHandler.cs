using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAlignmentQueryHandler : IRequestHandler<GetAlignmentQuery, AlignmentDTO>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public GetAlignmentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<AlignmentDTO> Handle(GetAlignmentQuery request, CancellationToken cancellationToken)
        {
            var Alignment = UnitOfWork.Alignment.SingleOrDefaultById(request.Id);
            return Mapper.Map<AlignmentDTO>(Alignment);
        }
    }
}
