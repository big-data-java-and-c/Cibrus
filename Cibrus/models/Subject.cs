using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    [Table("subject")] //subjects
    public class Subject
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SubjectId { get; set; }
        public string name { get; set; }
        public int value_ECTS { get; set; }

        // many to many teacher
        public ICollection<Teacher> Teacher { get; set; }

        // one to many grade
        public int GradeId { get; set; }
        
        public Grade Grade { get; set; }

        // one to many lesson
       public int GradeId { get; set; }
          public Lesson Lesson { get; set; }

        public Subject()
        {

        }

    }
}

