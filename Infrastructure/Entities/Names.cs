using System;
using System.Collections.Generic;
using System.Text;
using NPoco;

namespace Infrastructure.Entities
{
    [TableName("NAMES")]
    [PrimaryKey("Id")]
    public class Names
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("RACE_ID")]
        public int RaceId { get; set; }

        [Column("GENDER_ID")]
        public int GenderId { get; set; }

        [Column("NAME")]
        public int Name { get; set; }
    }
}
