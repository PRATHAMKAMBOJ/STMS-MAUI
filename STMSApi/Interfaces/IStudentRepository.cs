using STMSApi.Models;

namespace STMSApi.Interfaces
{
    public interface IStudentRepository
    {
        public  Task<List<Student>> GetAllStudent();
        public  Task<Student> GetStudentById(int rollnumber);
        public  Task<bool> AddStudent(Student studentDetails);
        public  Task<bool> DeleteStudentById(int id);
        public Task<bool> UpdateStudentById(int id, Student studentDetails);
    }
}
