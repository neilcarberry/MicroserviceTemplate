using AutoMapper;
using Domain.AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Domain.Models
{
    public class BaseModel<TEntity> 
    {
        internal IMapper Mapper { private get; set; }
        public void SetUpMapper(IMapper mapper)
        {
            Mapper = mapper;
        }
        public TEntity MapToEntity()
        {
            var g = this.GetType();
            return Mapper.Map<TEntity>(g);
        }
    }
}