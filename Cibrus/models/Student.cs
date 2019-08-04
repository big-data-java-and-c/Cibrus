using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        [JsonProperty(PropertyName = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentId { get; set; }
        public string displayName { get; set; } 
        public string address { get; set; }
        public string city { get; set; } 
        public string province { get; set; } 
        public string zip_code { get; set; }  
        public string phone_number { get; set; } 
                
        public int GropuId { get; set; }
        public Group Group { get; set; }

        // one to one user
        [Column("user_id")]
        [ForeignKey("User")]
        [JsonIgnore]
        public int UserId { get; set; }
        public virtual User User { get; set; }

       
        
        public Student()
        {

        }

    }
}
 

