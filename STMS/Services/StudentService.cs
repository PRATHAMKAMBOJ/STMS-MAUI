using Newtonsoft.Json;
using STMS.Interfaces;
using STMS.MVVM.Models;
using System.Text;

namespace STMS.Services
{
    public class StudentService : IStudentService
    {
        public IAuthService _authService;
        public string baseUrl = "https://e694-112-196-9-90.ngrok-free.app/api/";
        public StudentService()
        {
            _authService = new AuthService();
        }
        //Add Student in Database
        public async Task<bool> AddStudent(Student StudentDetails)
        {
            string jwt = await _authService.GetJwtToken();
            using (var _client = new HttpClient())
            {
                var data = new
                {
                    name = StudentDetails.Name,
                    @class = StudentDetails.Class,
                    age = StudentDetails.Age,
                    section = StudentDetails.Section,
                    image = StudentDetails.Image
                };
                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(baseUrl + "AddStudent", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Update Student in Database
        public async Task<bool> UpdateStudent(Student StudentDetails)
        {
            using (var _client = new HttpClient())
            {
                var data = new
                {
                    name = StudentDetails.Name,
                    @class = StudentDetails.Class,
                    age = StudentDetails.Age,
                    section = StudentDetails.Section,
                    image = StudentDetails.Image
                };
                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(baseUrl+$"UpdateStudentById/{StudentDetails.Rollnumber}", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Delete Student from Database
        public async Task<bool> DeleteStudent(string rollNumber)
        {
            using (var _client = new HttpClient())
            {
                var response = await _client.DeleteAsync(baseUrl+$"DeleteStudentById/{rollNumber}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        //Get List of all students
        public async Task<List<Student>> GetAllStudents()
        {
            using (var _client = new HttpClient())
            {
                var response = await _client.GetAsync(baseUrl + "GetAllStudent");
                string json = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<Student>>(json);
                return [.. students];
            }
        }
    }
}
