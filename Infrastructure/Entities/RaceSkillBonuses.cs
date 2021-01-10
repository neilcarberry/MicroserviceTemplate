using System;
using System.Collections.Generic;
using System.Text;
using NPoco;

namespace Infrastructure.Entities
{
    [TableName("RACE_SKILL_BONUSES")]
    [PrimaryKey("Id")]
    public class RaceSkillBonuses
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
