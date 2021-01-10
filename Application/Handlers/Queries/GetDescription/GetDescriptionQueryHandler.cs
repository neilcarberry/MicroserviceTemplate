using Application.Abstractions;
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
    public class GetDescriptionQueryHandler : BaseHandler<GetDescriptionQuery, List<DescriptionDTO>>
    {

        public GetDescriptionQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<DescriptionDTO>> HandleEx(GetDescriptionQuery request, CancellationToken cancellationToken)
        {
            var descriptions = await UnitOfWork.Description.GetAllAsync();

            var descriptionsDTO = request.Id == 0 ? Mapper.Map<List<DescriptionDTO>>(descriptions).ToList() : Mapper.Map<List<DescriptionDTO>>(descriptions.Where(x => x.Id == request.Id)).ToList();

            return descriptionsDTO;
        }
    }
}
