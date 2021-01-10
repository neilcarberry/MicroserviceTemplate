using Application.Abstractions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetStoryQueryHandler : BaseHandler<GetStoryQuery, List<StoryDTO>>
    {
        public GetStoryQueryHandler(ICoreAggregator coreAggregator):base(coreAggregator)
        {
        }
        public override async Task<List<StoryDTO>> HandleEx(GetStoryQuery request, CancellationToken cancellationToken)
        {
            var storys = await UnitOfWork.Description.GetAllAsync();

            var storysDTO = request.Id == 0 ? Mapper.Map<List<StoryDTO>>(storys).ToList() : Mapper.Map<List<StoryDTO>>(storys.Where(x => x.Id == request.Id)).ToList();

            return storysDTO;
        }
    }
}
