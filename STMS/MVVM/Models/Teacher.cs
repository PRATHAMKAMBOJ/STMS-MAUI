using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Teacher
    {
        [JsonProperty("name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [JsonProperty("age")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age cannot be empty")]
        public string Age { get; set; }
        [JsonProperty("classAssigned")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select class*")]
        public string ClassAssigned { get; set; }
        [JsonProperty("teacherId")]
        public string TeacherId { get; set; }
        [JsonProperty("section")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Section Cannot be empty")]
        public string Section { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
