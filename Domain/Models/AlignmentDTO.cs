using Infrastructure.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class AlignmentDTO : IMapFrom<Alignment>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
