using PropertyChanged;
using STMS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.MVVM.ViewModels.TeacherViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class TeacherListViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }
    }
}
