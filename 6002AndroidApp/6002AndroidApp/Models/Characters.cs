using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002AndroidApp.Models
{
    [Table("characters")]
    public class Character : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("account_id")]
        public string AccountID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("imageURL")]
        public string ImageURL { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("statName1")]
        public string statName1 { get; set; }

        [Column("statName2")]
        public string statName2 { get; set; }

        [Column("statName3")]
        public string statName3 { get; set; }

        [Column("statName4")]
        public string statName4 { get; set; }

        [Column("statName5")]
        public string statName5 { get; set; }

        [Column("statName6")]
        public string statName6 { get; set; }

        [Column("stat1")]
        public int stat1 { get; set; }

        [Column("stat2")]
        public int stat2 { get; set; }

        [Column("stat3")]
        public int stat3 { get; set; }

        [Column("stat4")]
        public int stat4 { get; set; }

        [Column("stat5")]
        public int stat5 { get; set; }

        [Column("stat6")]
        public int stat6 { get; set; }
    }
}
