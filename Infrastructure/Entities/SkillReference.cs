using NPoco;

namespace Infrastructure.Entities
{
    [TableName("SKILL_REFERENCE")]
    [PrimaryKey("Id")]
    public class SkillReference
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("SKILL")]
        public string Skill { get; set; }


    }
}
