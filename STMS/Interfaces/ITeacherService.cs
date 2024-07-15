using STMS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> AddTeacher(Teacher TeacherDetails);
        Task<bool> UpdateTeacher(Teacher TeacherDetails);
        Task<bool> DeleteTeacher(string TeacherId);
        Task<List<Teacher>> GetAllTeachers();
    }
}
