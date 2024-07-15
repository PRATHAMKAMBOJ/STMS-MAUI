using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace STMSApi.Models
{
    public class Student
    {
        [Key]
        public int RollNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public string Section { get; set; }
        public string Image { get; set; }
    }
}
