using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    [Table("grade")]
    public class Grade
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeId { get; set; }
        public int value_grade { get; set; }
        public string date_received { get; set; }

     // many to one student
      public ICollection<Student> Student { get; set; }
     // many to one teacher
      public ICollection<Teacher> Teacher { get; set; }
     // many to one subject
      public ICollection<Subject> Subject { get; set; }
     
    
        public Grade()
        {

        }

    }
}
