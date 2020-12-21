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
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, List<GenderDTO>>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;
        public GetGendersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<List<GenderDTO>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            var Genders = await UnitOfWork.Gender.GetAllAsync();

            var GenderDTO = Mapper.Map<List<GenderDTO>>(Genders).ToList();

            return GenderDTO;
        }
    }
}
