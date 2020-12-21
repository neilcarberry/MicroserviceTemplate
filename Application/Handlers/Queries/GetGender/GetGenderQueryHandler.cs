using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetGenderQueryHandler : IRequestHandler<GetGenderQuery, GenderDTO>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public GetGenderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<GenderDTO> Handle(GetGenderQuery request, CancellationToken cancellationToken)
        {
            var Gender = UnitOfWork.Gender.SingleOrDefaultById(request.Id);
            return Mapper.Map<GenderDTO>(Gender);
        }
    }
}
