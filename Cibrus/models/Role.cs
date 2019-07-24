using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{

    public enum RoleName
    {
        STUDENT = 1,
        TEACHER = 2,
        ADMIN = 3
    }
    [Table("roles")]
    public class Role
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoleId { get; set; }

        [Column("role_type")]
        public string name { get; set; }

        public Role()
        {

        }

    }
}
