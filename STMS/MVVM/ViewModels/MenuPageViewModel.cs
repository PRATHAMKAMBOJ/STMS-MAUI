using PropertyChanged;
using STMS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MenuPageViewModel
    {
        public string UserName { get; set; }
        public ObservableCollection<FlyoutPageItem> FlyoutPageItems { get; set; }
        public MenuPageViewModel()
        {
            FlyoutPageItems = new ObservableCollection<FlyoutPageItem>();
            FlyoutPageItems.Add(new FlyoutPageItem { Title = "Home", MenuIcon = "home_icon.png" });
            FlyoutPageItems.Add(new FlyoutPageItem { Title = "Student List", MenuIcon = "student_icon.png" });
            FlyoutPageItems.Add(new FlyoutPageItem { Title = "Teacher List", MenuIcon = "teacher_icon.png" });
        }
        public MenuPageViewModel(string username)
        {
            UserName = username;
        }
    }
}
