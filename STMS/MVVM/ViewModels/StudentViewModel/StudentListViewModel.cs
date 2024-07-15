using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.Services;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels.StudentViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class StudentListViewModel
    {
        //ListOfAllStudents
        public List<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }
    }

}
