using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.Services;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels.TeacherViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AddTeacherViewModel
    {
        public ValidationHandler ValidationMsg { get; set; }
        public Teacher Teacher { get; set; }
        public AddTeacherViewModel()
        {
            Teacher = new Teacher();
            ValidationMsg = new ValidationHandler();
            SetDefaultImage();
        }

        #region Private Methods
        private void SetDefaultImage()
        {
            Teacher.Image = "addimage_logo.png";
        }
        #endregion
    }
}
