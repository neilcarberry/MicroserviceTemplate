using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetNamesQueryHandler : BaseHandler<GetNamesQuery, NamesDTO>
    {

        public GetNamesQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<NamesDTO> HandleEx(GetNamesQuery request, CancellationToken cancellationToken)
        {
            var Names = UnitOfWork.Names.SingleOrDefaultById(request.Id);
            return Mapper.Map<NamesDTO>(Names);
        }
    }
}
