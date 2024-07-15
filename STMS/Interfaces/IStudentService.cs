using STMS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.Interfaces
{
    public interface IStudentService
    {
        Task<bool> AddStudent(Student StudentDetails);
        Task<bool> UpdateStudent(Student StudentDetails);
        Task<bool> DeleteStudent(string rollNumber);
        Task<List<Student>> GetAllStudents();
    }
}
