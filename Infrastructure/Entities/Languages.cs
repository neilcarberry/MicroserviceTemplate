using NPoco;

namespace Infrastructure.Entities
{
    [TableName("LANGUAGES")]
    [PrimaryKey("Id")]
    public class Languages
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("LANGUAGE")]
        public string Language { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
