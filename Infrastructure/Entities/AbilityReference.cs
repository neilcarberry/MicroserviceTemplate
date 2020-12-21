using NPoco;

namespace Infrastructure.Entities
{
    [TableName("ABILITY_REFERENCE")]
    [PrimaryKey("Id")]
    public class AbilityReference
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Ability")]
        public int Ability { get; set; }
    }
}
