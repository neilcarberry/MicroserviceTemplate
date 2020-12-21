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
    public class GetAlignmentsQueryHandler : IRequestHandler<GetAlignmentsQuery, List<AlignmentDTO>>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;
        public GetAlignmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<List<AlignmentDTO>> Handle(GetAlignmentsQuery request, CancellationToken cancellationToken)
        {
            var Alignments = await UnitOfWork.Alignment.GetAllAsync();

            var AlignmentDTO = Mapper.Map<List<AlignmentDTO>>(Alignments).ToList();

            return AlignmentDTO;
        }
    }
}
