using Infrastructure.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class GenderDTO : IMapFrom<Genders>
    {
        public int Id { get; set; }
        public string Gender { get; set; }
    }
}
