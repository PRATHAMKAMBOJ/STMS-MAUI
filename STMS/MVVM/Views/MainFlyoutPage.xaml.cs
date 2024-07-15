using STMS.MVVM.Models;
using STMS.MVVM.Views.TeacherPages;

namespace STMS.MVVM.Views;

public partial class MainFlyoutPage : FlyoutPage
{
    public static string username = string.Empty;
	public MainFlyoutPage(string Username)
	{
		InitializeComponent();
        username = Username;
        flyoutPage.collectionViewFlyout.SelectionChanged += OnSelectionChanged;
    }
    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {

            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;

            switch (item.Title)
            {
                case "Home":
                    Detail = new NavigationPage(new HomePage(username));
                    break;

                case "Student List":
                    Detail = new NavigationPage(new StudentListPage());
                    break;

                case "Teacher List":
                    Detail = new NavigationPage(new TeacherListPage());
                    break;
            }
        }
    }
}