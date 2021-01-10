using NPoco;

namespace Infrastructure.Entities
{
    [TableName("RACE_LANGUAGE")]
    [PrimaryKey("Id")]
    public class RaceLanguage
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_ID")]
        public int RaceId { get; set; }

        [Column("LANGUAGE_ID")]
        public int LanguageId { get; set; }
    }
}
