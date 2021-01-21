using Infrastructure.Interfaces;
using NPoco;

namespace Infrastructure.Entities
{
    [TableName("ABILITY_MODIFIERS")]
    [PrimaryKey("Id")]
    public class Auction 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("SELLER_ID")]
        public int SellerID { get; set; }

        [Column("AUCTIONEER_ID")]
        public int AuctioneerId { get; set; }

        [Column("VEHICLE_ID")]
        public int Vehicle { get; set; }
    }
}
