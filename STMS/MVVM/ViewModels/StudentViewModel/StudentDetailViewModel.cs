using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.Services;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels.StudentViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class StudentDetailViewModel
    {
        public ValidationHandler ValidationMsg { get; set; }

        public IStudentService _studentServices;

        public Student SelectedStudent { get; set; }
        public StudentDetailViewModel(Student selectedStudent)
        {
            _studentServices = new StudentService();
            SelectedStudent = selectedStudent;
            ValidationMsg = new ValidationHandler();
        }
    }
}
