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
    public class GetNamessQueryHandler : BaseHandler<GetNamessQuery, List<NamesDTO>>
    {
        public GetNamessQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<NamesDTO>> HandleEx(GetNamessQuery request, CancellationToken cancellationToken)
        {
            var Namess = await UnitOfWork.Names.GetAllAsync();

            var NamesDTO = Mapper.Map<List<NamesDTO>>(Namess).ToList();

            return NamesDTO;
        }
    }
}
