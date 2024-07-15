using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels.TeacherViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class TeacherDetailViewModel
    {
        public ValidationHandler ValidationMsg { get; set; }

        public IStudentService _studentServices;

        public Teacher SelectedTeacher { get; set; }
        public TeacherDetailViewModel(Teacher selectedTeacher)
        {
            SelectedTeacher = selectedTeacher;
            ValidationMsg = new ValidationHandler();
        }
    }
}
