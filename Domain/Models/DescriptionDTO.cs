using Domain.AutoMapper;
using Infrastructure.Entities;
using System.Configuration;

namespace Domain.Models
{
    public class DescriptionDTO : IMap<Descriptions>
    {
        public const string g="tst";
        public int Id { get; set; }
        public int RaceDescriptionId { get; set; }
        public string Description { get; set; }
    }
}
