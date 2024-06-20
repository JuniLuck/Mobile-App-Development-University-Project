using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002AndroidApp.Models
{
    [Table("inventory")]
    public class InventoryItem : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("characterID")]
        public int Character_ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("weight")]
        public float Weight { get; set; }
        
        [Column("value")]
        public float Value { get; set; }
    }
}
