using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels.TeacherViewModel;
using STMS.Services;

namespace STMS.MVVM.Views.TeacherPages;

public partial class TeacherListPage : ContentPage
{
    public ITeacherService _teacherService;
	public TeacherListPage()
	{
		InitializeComponent();
        BindingContext = new TeacherListViewModel();
        _teacherService = new TeacherService();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = (TeacherListViewModel)BindingContext;
        var teacherList = await _teacherService.GetAllTeachers();
        if (teacherList != null)
        {
            viewModel.Teachers = teacherList;
        }
    }
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var viewModel = (TeacherListViewModel)BindingContext;
        Teacher SelectedTeacher = viewModel.SelectedTeacher;
        await Navigation.PushAsync(new TeacherDetailPage(SelectedTeacher));
    }
    private async void AddStudentButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTeacherPage());
    }
}