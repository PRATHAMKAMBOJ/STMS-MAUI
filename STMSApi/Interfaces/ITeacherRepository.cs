using STMSApi.Models;

namespace STMSApi.Interfaces
{
    public interface ITeacherRepository
    {
        public  Task<List<Teacher>> GetAllTeacher();
        public  Task<Teacher> GetTeacherById(int teacherId);
        public  Task<bool> AddTeacher(Teacher teacherDetails);
        public  Task<bool> DeleteTeacherById(int id);
        public Task<bool> UpdateTeacherById(int id, Teacher teacherDetails);
    }
}
