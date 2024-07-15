using Newtonsoft.Json;
using STMS.Interfaces;
using STMS.MVVM.Models;
using System.Text;

namespace STMS.Services
{
    public class TeacherService : ITeacherService
    {
        public IAuthService _authService;
        public string baseUrl = "https://e694-112-196-9-90.ngrok-free.app/api/";
        public TeacherService()
        {
            _authService = new AuthService();
        }
        //Add Student in Database
        public async Task<bool> AddTeacher(Teacher TeacherDetails)
        {
            string jwt = await _authService.GetJwtToken();
            using (var _client = new HttpClient())
            {
                var data = new
                {
                    name = TeacherDetails.Name,
                    @class = TeacherDetails.ClassAssigned,
                    age = TeacherDetails.Age,
                    section = TeacherDetails.Section,
                    image = TeacherDetails.Image
                };
                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(baseUrl + "AddTeacher", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Update Student in Database
        public async Task<bool> UpdateTeacher(Teacher TeacherDetails)
        {
            using (var _client = new HttpClient())
            {
                var data = new
                {
                    name = TeacherDetails.Name,
                    @classAssigned = TeacherDetails.ClassAssigned,
                    age = TeacherDetails.Age,
                    section = TeacherDetails.Section,
                    image = TeacherDetails.Image
                };
                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(baseUrl + $"UpdateTeacherById/{TeacherDetails.TeacherId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Delete Student from Database
        public async Task<bool> DeleteTeacher(string TeacherId)
        {
            using (var _client = new HttpClient())
            {
                var response = await _client.DeleteAsync(baseUrl + $"DeleteTeacherById/{TeacherId}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Get List of all Teachers
        public async Task<List<Teacher>> GetAllTeachers()
        {
            using (var _client = new HttpClient())
            {
                var response = await _client.GetAsync(baseUrl + "GetAllTeachers");
                string json = await response.Content.ReadAsStringAsync();
                var teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
                if(teachers!=null)
                {
                    return [.. teachers];
                }
                return null;
            }
        }
    }
}

