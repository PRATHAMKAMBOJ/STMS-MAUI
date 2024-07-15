using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public DatabaseContext _dbContext;
        public TeacherRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _dbContext.Teachers.ToListAsync();
        }
        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(x=>x.TeacherId == teacherId);
        }
        public async Task<bool> AddTeacher(Teacher teacherDetails)
        {
            try
            {
                await _dbContext.Teachers.AddAsync(teacherDetails);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteTeacherById(int id)
        {
            try
            {
                var teacher = await GetTeacherById(id);
                if (teacher != null)
                {
                    _dbContext.Teachers.Remove(teacher);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex) 
            {
                return false;
            }

        }
        public async Task<bool> UpdateTeacherById(int id,Teacher teacherDetails)
        {
            try
            {
                var teacher = await GetTeacherById(id);
                if(teacher != null)
                {
                    teacher.Name = teacherDetails.Name;
                    teacher.Section = teacherDetails.Section;
                    teacher.Age = teacherDetails.Age;
                    teacher.ClassAssigned = teacherDetails.ClassAssigned;
                    teacher.Image = teacherDetails.Image;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
