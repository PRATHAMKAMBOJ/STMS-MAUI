using STMS.MVVM.ViewModels;

namespace STMS.MVVM.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }

    
}