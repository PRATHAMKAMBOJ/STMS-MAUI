using STMS.Interfaces;
using STMS.MVVM.Models;
using STMS.MVVM.ViewModels.TeacherViewModel;
using STMS.Services;
using System.ComponentModel.DataAnnotations;

namespace STMS.MVVM.Views.TeacherPages;

public partial class AddTeacherPage : ContentPage
{
    public ITeacherService _teacherService;
    public AddTeacherPage()
    {
        InitializeComponent();
        BindingContext = new AddTeacherViewModel();
        _teacherService = new TeacherService();
    }

    #region Private Methods

    //Event: Student Image Selected
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
    //Event: Student Is Added
    private async void OnAddStudentButton(object sender, EventArgs e)
    {
        Teacher Teacher = ((AddTeacherViewModel)BindingContext).Teacher;
        CheckValidation();
        var result = await _teacherService.AddTeacher(Teacher);
        if (result)
        {
            await DisplayAlert("Alert", "Student added successfully", "OK");
            await Navigation.PopAsync();
        }
    }
    
    private async Task CaptureImageFromCamera()
    {
        Teacher Teacher = ((AddTeacherViewModel)BindingContext).Teacher;
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
        Teacher Teacher = ((AddTeacherViewModel)BindingContext).Teacher;
        var options = new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Select an image"
        };
        var file = await FilePicker.PickAsync(options);
        if (file != null)
        {
            Teacher.Image = file.FullPath;
        }
    }
    private void CheckValidation()
    {
        Teacher Teacher = ((AddTeacherViewModel)BindingContext).Teacher;
        var ValidationMsg = ((AddTeacherViewModel)BindingContext).ValidationMsg;
        ValidationMsg.NameValidation = "";
        ValidationMsg.AgeValidation = "";
        ValidationMsg.ClassValidation = "";
        ValidationMsg.SectionValidation = "";
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(Teacher, new ValidationContext(Teacher), validationResults, true);
        if (!isValid)
        {
            foreach (var validationResult in validationResults)
            {
                if (validationResult.MemberNames.First() == "Name")
                {
                    ValidationMsg.NameValidation = validationResult.ErrorMessage;
                }
                if (validationResult.MemberNames.First() == "Age")
                {
                    ValidationMsg.AgeValidation = validationResult.ErrorMessage;
                }
                if (validationResult.MemberNames.First() == "Class")
                {
                    ValidationMsg.ClassValidation = validationResult.ErrorMessage;
                }
                if (validationResult.MemberNames.First() == "Section")
                {
                    ValidationMsg.SectionValidation = validationResult.ErrorMessage;
                }
            }
        }
    }
    #endregion
}