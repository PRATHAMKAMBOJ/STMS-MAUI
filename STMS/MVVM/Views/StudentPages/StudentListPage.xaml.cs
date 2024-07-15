using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels.StudentViewModel;
using STMS.MVVM.Views.StudentPages;
using STMS.Services;

namespace STMS.MVVM.Views;

public partial class StudentListPage : ContentPage
{
    public IStudentService _studentService;
    public StudentListPage()
    {
        InitializeComponent();
        _studentService = new StudentService();
        BindingContext = new StudentListViewModel();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = (StudentListViewModel)BindingContext;
        var studentList = await _studentService.GetAllStudents();
        if(studentList!=null)
        {
            viewModel.Students = studentList;
        }
    }
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var viewModel = (StudentListViewModel)BindingContext;
        Student SelectedStudent = viewModel.SelectedStudent;
        await Navigation.PushAsync(new StudentDetailPage(SelectedStudent));
    }
    private async void AddStudentButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddStudentPage());
    }
}