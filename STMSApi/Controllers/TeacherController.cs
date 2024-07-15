using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Controllers
{

    [ApiController]
    public class TeacherController : ControllerBase
    {
        public ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        [Route("api/GetTeacherById/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            try
            {
                var result = await _teacherRepository.GetTeacherById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/GetAllTeachers")]
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var result = await _teacherRepository.GetAllTeacher();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/DeleteTeacherById/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTeacherById(int id)
        {
            try
            {
                var result = await _teacherRepository.DeleteTeacherById(id);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/AddTeacher")]
        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacherDetails)
        {
            try
            {
                var result = await _teacherRepository.AddTeacher(teacherDetails);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/UpdateTeacherById/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTeacherById(int id,Teacher teacherDetails)
        {
            try
            {
                var result = await _teacherRepository.UpdateTeacherById(id, teacherDetails);
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
    }
}
