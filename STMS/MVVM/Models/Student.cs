using Newtonsoft.Json;
using PropertyChanged;
using STMS.Annotation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace STMS.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Student
    {
        [JsonProperty("name")]
        [Required(AllowEmptyStrings = false,ErrorMessage ="Name cannot be empty*")]
        public string Name { get; set; }
        [JsonProperty("age")]
        [Required(ErrorMessage ="Age is Required*")]
        [Range(0,100,ErrorMessage ="Enter a Valid age*")]
        public int Age { get; set; }
        [JsonProperty("class")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select class*")]
        public string Class { get; set; }
        [JsonProperty("rollNumber")]
        public string Rollnumber { get; set; }
        [JsonProperty("section")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Section Cannot be empty*")]
        public string Section { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
