using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    [Table("lesson")]
    public class Lesson
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LessonId { get; set; }
        public Date date_lesson { get; set; }
        public string sign_hall { get; set; }

        // many to one teacher
        public ICollection<Teacher> Teacher { get; set; }
        // many to one subject
        public ICollection<Subject> Subject { get; set; }
        // many to one group 
        public ICollection<Group> Group { get; set; }

        public Lesson()
        {

        }

    }
}
