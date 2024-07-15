using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Controllers
{

    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [Route("api/GetStudentById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var result = await _studentRepository.GetStudentById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/GetAllStudent")]
        [HttpGet]
        public async Task<IActionResult> GetAllStundets()
        {
            try
            {
                var result = await _studentRepository.GetAllStudent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/DeleteStudentById/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            try
            {
                var result = await _studentRepository.DeleteStudentById(id);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student studentDetails)
        {
            try
            {
                var result = await _studentRepository.AddStudent(studentDetails);
                if(result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/UpdateStudentById/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudentById(int id, Student studentDetails)
        {
            try
            {
                var result = await _studentRepository.UpdateStudentById(id, studentDetails);
                if (result)
                {
                    return Ok();
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
