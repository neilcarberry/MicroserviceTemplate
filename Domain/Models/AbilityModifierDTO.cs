using Application.Abstractions;
using AutoMapper;
using Domain.AutoMapper;
using Infrastructure.Entities;

namespace Domain.Models
{
    public class AbilityModifierDTO : BaseModel<AbilityModifier>, IMap<AbilityModifier> 
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int Modifier { get; set; }
        public int AbilityId { get; set; }       
    }
}