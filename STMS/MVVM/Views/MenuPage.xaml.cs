using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels;
using STMS.MVVM.Views.TeacherPages;
using STMS.Services;
using System.Collections.ObjectModel;

namespace STMS.MVVM.Views;

public partial class MenuPage : ContentPage
{
   
    public IAuthService _authService;
    

    public MenuPage()
	{
        InitializeComponent();
        _authService = new AuthService();
        BindingContext = new MenuPageViewModel();
	}
    private void LogoutButtonHandler(object sender, EventArgs e)
    {
        _authService.Logout();
        Navigation.PopToRootAsync();
    }
}