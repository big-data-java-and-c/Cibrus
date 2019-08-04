using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{

    [Table("teacher")] // lub teachers
    public class Teacher
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("salary")]
        private int salary { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        [JsonIgnore]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public Teacher()
        {

        }

    }
}
