using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace STMSApi.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ClassAssigned { get; set; }
        public int Age { get; set; }
        public string Section { get; set; }
        public string Image { get; set; }
    }
}
