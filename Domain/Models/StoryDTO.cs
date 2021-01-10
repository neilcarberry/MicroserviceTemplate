using AutoMapper;
using Domain.AutoMapper;
using Domain.Interfaces;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class StoryDTO : IMap<Storys>
    {
        internal IMapper Mapper;
        public StoryDTO(IModelAggregator modelAggregator)
        {
            Mapper = modelAggregator.Mapper;
        }
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int Story { get; set; }
        internal Storys MapToEntity()
        {
            return Mapper.Map<Storys>(this);
        }
    }
}
