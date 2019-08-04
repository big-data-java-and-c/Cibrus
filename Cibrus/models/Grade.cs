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

       
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public Grade()
        {

        }

    }
}
