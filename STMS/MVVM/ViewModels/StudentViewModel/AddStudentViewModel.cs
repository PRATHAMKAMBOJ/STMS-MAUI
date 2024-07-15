using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.Services;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels.StudentViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AddStudentViewModel
    {
        public ValidationHandler ValidationMsg { get; set; }
        public Student Student { get; set; }
        public AddStudentViewModel()
        {
            Student = new Student();
            ValidationMsg = new ValidationHandler();
            SetDefaultImage();
        }

        #region Private Methods
        private void SetDefaultImage()
        {
            Student.Image = "addimage_logo.png";
        }
        #endregion
    }
}
