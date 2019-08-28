using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        [Column("roles_id")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Role Roles { get; set; }

        public User()
        {

        }

    }
}
