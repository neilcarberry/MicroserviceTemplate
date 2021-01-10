using NPoco;

namespace Domain.Models
{
    [TableName("RACE_SKILL_BONUESES")]
    [PrimaryKey("Id")]
    public class SkillBonusDTO
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_ID")]
        public int RaceId { get; set; }

        [Column("MODIFIER")]
        public int Modifier { get; set; }

        [Column("SKILL_ID")]
        public int SkillId { get; set; }
    }
}
