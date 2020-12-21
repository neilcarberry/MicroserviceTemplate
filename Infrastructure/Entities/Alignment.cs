using NPoco;

namespace Infrastructure.Entities
{
    [TableName("ALIGNMENT")]
    [PrimaryKey("Id")]
    public class Alignment 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
