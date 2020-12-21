using Infrastructure.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class LanguageDTO : IMapFrom<Languages>
    {
        public int Id { get; set; }
        public int Language { get; set; }
        public int Description { get; set; }
    }
}
