using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ValidationHandler
    {
        public string NameValidation { get; set; }
        public string AgeValidation { get; set; }
        public string ClassValidation { get; set; }
        public string SectionValidation { get; set; }
    }
}
