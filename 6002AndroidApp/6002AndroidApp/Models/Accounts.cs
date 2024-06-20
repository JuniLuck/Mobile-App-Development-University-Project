using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace _6002AndroidApp.Models
{
    [Table("accounts")]
    public class Account : BaseModel
    {
        [PrimaryKey("account_id", true)]
        public string AccountId { get; set; }

        [Column("username")]
        public string Username { get; set; }
    }
}
