using NPoco;

namespace Infrastructure.Entities
{
    [TableName("BASE_DETAILS")]
    [PrimaryKey("ID")]
    public class BaseDetails 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("GENDER_ID")]
        public int GenderId { get; set; }

        [Column("ALIGNMENT_ID")]
        public int AlignmentId { get; set; }

        [Column("SIZE")]
        public string Size { get; set; }

        [Column("SPEED")]
        public int Speed { get; set; }

        [Column("VISION")]
        public int Vision { get; set; }
    }
}
