using Infrastructure.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class AbilityReferenceDTO : IMapFrom<AbilityReference>
    {
        public int Id { get; set; }
        public string Ability { get; set; }
    }
}
