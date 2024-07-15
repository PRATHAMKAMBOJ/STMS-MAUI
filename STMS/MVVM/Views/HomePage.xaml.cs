using PropertyChanged;
using STMS.MVVM.ViewModels;

namespace STMS.MVVM.Views;
public partial class HomePage : ContentPage
{
    public HomePage(string username)
	{
		InitializeComponent();
		BindingContext = new MenuPageViewModel(username);
	}
}