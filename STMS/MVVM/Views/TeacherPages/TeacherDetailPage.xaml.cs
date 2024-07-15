using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels.TeacherViewModel;
using STMS.Services;

namespace STMS.MVVM.Views.TeacherPages;

public partial class TeacherDetailPage : ContentPage
{
    public ITeacherService _teacherService;
    public TeacherDetailPage(Teacher selectedTeacher)
    {
        InitializeComponent();
        _teacherService = new TeacherService();
        BindingContext = new TeacherDetailViewModel(selectedTeacher);
    }

    #region Private Method

    //Event: Delete button is clicked
    private async void OnDeleteButton(object sender, EventArgs e)
    {
        Teacher SelectedTeacher = ((TeacherDetailViewModel)BindingContext).SelectedTeacher;
        bool answer = await DisplayAlert("Confirm?", "Do you want to delete", "Yes", "No");
        if (answer)
        {
            await _teacherService.DeleteTeacher(SelectedTeacher.TeacherId);
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
        Teacher SelectedTeacher = ((TeacherDetailViewModel)BindingContext).SelectedTeacher;
        await _teacherService.UpdateTeacher(SelectedTeacher);
        await DisplayAlert("Alert", "Student updated successfully", "OK");
        await Navigation.PopAsync();
    }


    
    private async Task CaptureImageFromCamera()
    {
        Teacher Teacher = ((TeacherDetailViewModel)BindingContext).SelectedTeacher;
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
                Teacher.Image = filePath;
            }
        }
    }
    async Task SelectImageFiles()
    {
        Teacher SelectedTeacher = ((TeacherDetailViewModel)BindingContext).SelectedTeacher;
        var options = new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Select an image"
        };
        var file = await FilePicker.PickAsync(options);
        if (file != null)
        {
            SelectedTeacher.Image = file.FullPath;
        }
    }
    #endregion
}