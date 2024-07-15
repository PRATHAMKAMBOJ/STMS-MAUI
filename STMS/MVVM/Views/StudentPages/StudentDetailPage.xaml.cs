using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels.StudentViewModel;
using STMS.Services;

namespace STMS.MVVM.Views;

public partial class StudentDetailPage : ContentPage
{
    public IStudentService _studentService;
    public StudentDetailPage(Student selectedStudent)
	{
		InitializeComponent();
        _studentService = new StudentService();
		BindingContext = new StudentDetailViewModel(selectedStudent);
	}

    #region Private Method
    //Event: Delete button is clicked
    private async void OnDeleteButton(object sender, EventArgs e)
    {
        Student SelectedStudent = ((StudentDetailViewModel)BindingContext).SelectedStudent;
        bool answer = await DisplayAlert("Confirm?", "Do you want to delete", "Yes", "No");
        if(answer)
        {
            await _studentService.DeleteStudent(SelectedStudent.Rollnumber);
            await Navigation.PopAsync();
        }
    }

    //Event: Image icon is Clicked
    private async void OnImageSelect(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Choose", "Upload image from", "Files", "Camera");
        if (answer)
        {
            await SelectImageFiles();
        }
        else
        {
            await CaptureImageFromCamera();
        }
    }

    //event: Save button is clicked
    private async void OnStudentSave(object sender, EventArgs e)
    {
        Student SelectedStudent = ((StudentDetailViewModel)BindingContext).SelectedStudent;
        await _studentService.UpdateStudent(SelectedStudent);
        await DisplayAlert("Alert", "Student updated successfully", "OK");
        await Navigation.PopAsync();
    }


    
    private async Task CaptureImageFromCamera()
    {
        Student Student = ((StudentDetailViewModel)BindingContext).SelectedStudent;
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult myPhoto = await MediaPicker.Default.CapturePhotoAsync();
            if (myPhoto != null)
            {

                string fileName = Path.GetFileName(myPhoto.FileName);
                string extension = Path.GetExtension(fileName);
                string uniqueFileName = Guid.NewGuid().ToString() + extension;
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folderPath = Path.Combine(downloadsPath, "Download");
                Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, uniqueFileName);
                // Save the image to the specified path
                using (Stream sourceStream = await myPhoto.OpenReadAsync())
                {
                    using (FileStream fileStream = File.Create(filePath))
                    {
                        await sourceStream.CopyToAsync(fileStream);
                    }
                }
                Student.Image = filePath;
            }
        }
    }
    async Task SelectImageFiles()
    {
        Student SelectedStudent = ((StudentDetailViewModel)BindingContext).SelectedStudent;
        var options = new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Select an image"
        };
        var file = await FilePicker.PickAsync(options);
        if (file != null)
        {
            SelectedStudent.Image = file.FullPath;
        }
    }
    #endregion
}