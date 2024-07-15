using PropertyChanged;
using STMS.Interfaces;
using STMS.MVVM.Views;
using STMS.Services;
using System.Windows.Input;

namespace STMS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public string LoginPageOpacity { get; set; }
        public string IsLoaderVisible { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StatusMessage { get; set; }
        public string IsErrorVisible { get; set; }

        public IAuthService _authService;

        public INavigation Navigation;
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            IsLoaderVisible = "false";
            IsErrorVisible = "false";
            LoginPageOpacity = "1";
            _authService = new AuthService();

        }
        public ICommand LoginCommand => new Command(async () =>
        {
            IsLoaderVisible = "true";
            LoginPageOpacity = "0.4";
            var result = await _authService.Login(Username, Password);
            if (result != null)
            {
                LoginPageOpacity = "1";
                IsErrorVisible = "false";
                IsLoaderVisible = "false";
                Username = "";
                Password = "";
                await Navigation.PushAsync(new MainFlyoutPage(result.User.Username));
            }
            else
            {
                LoginPageOpacity = "1";
                IsLoaderVisible = "false";
                StatusMessage = "Incorrect Username/Password";
                IsErrorVisible = "true";
            }
        });
    }
}
