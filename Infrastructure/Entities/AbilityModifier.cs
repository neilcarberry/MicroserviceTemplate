using Infrastructure.Interfaces;
using NPoco;

namespace Infrastructure.Entities
{
    [TableName("ABILITY_MODIFIERS")]
    [PrimaryKey("Id")]
    public class AbilityModifier : IEntity
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_ID")]
        public int RaceId { get; set; }

        [Column("MODIFIER")]
        public int Modifier { get; set; }

        [Column("ABILITY_ID")]
        public int AbilityId { get; set; }
    }
}
