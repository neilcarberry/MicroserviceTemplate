using NPoco;

namespace Infrastructure.Entities
{
    [TableName("STORY")]
    [PrimaryKey("Id")]
    public class Storys
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_ID")]
        public int RaceId { get; set; }

        [Column("STORY")]
        public int Story { get; set; }
    }
}