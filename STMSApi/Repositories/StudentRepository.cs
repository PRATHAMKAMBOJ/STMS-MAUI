using Microsoft.EntityFrameworkCore;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public DatabaseContext _dbContext;
        public StudentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllStudent()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int rollnumber)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.RollNumber == rollnumber);
        }
        public async Task<bool> AddStudent(Student studentDetails)
        {
            try
            {
                await _dbContext.Students.AddAsync(studentDetails);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteStudentById(int id)
        {
            var student = await GetStudentById(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateStudentById(int id, Student studentDetails)
        {
            try
            {
                var student = await GetStudentById(id);
                if (student != null)
                {
                    student.Name = studentDetails.Name;
                    student.Section = studentDetails.Section;
                    student.Age = studentDetails.Age;
                    student.Class = studentDetails.Class;
                    student.Image = studentDetails.Image;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
