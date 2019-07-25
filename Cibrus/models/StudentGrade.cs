using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Cibrus.models
{
    //[Table("student_nn_grade")]  
    public class StudentGrade
    {

        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        [Key]
        public int StudentGradetId { get; set; }

        public int StudentID { get; set; }
      
        public int GradeID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Grade Grade { get; set; }

    }
}
