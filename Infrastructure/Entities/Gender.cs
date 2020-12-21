using System;
using System.Collections.Generic;
using System.Text;
using NPoco;

namespace Infrastructure.Entities
{
    [TableName("GENDER")]
    [PrimaryKey("Id")]
    public class Genders
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("GENDER")]
        public string Gender { get; set; }
    }
}
