using NPoco;

namespace Infrastructure.Entities
{
    [TableName("DESCRIPTION")]
    [PrimaryKey("Id")]
    public class Descriptions
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_DESCRIPTION_ID")]
        public int RaceDescriptionId { get; set; }

        [Column("DESCRIPTION")]
        public int Description { get; set; }
    }
}
