using Domain.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class BaseDetailsDTO : IMap<BaseDetails>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenderId { get; set; }
        public int AlignmentId { get; set; }
        public string Size { get; set; }
        public int Speed { get; set; }
        public int Vision { get; set; }

        /*** use when Infrastructure.entity is different from Domain.models dto
         *** to map the data from what we want to where we want   
        public void CreateMappings(Profile configuration)
        {
          /*  configuration.CreateMap<Courier, CourierDto>()
              .ForMember(destination => destination.CourierDescription,
                  opts => opts.MapFrom(source => source.CourierName + " : " + source.ServiceCode));
        }*/
    }
}
