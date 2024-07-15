using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthenticateService _authService;
        public AuthController(IAuthenticateService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        [Route("api/Login")]
        public async Task<IActionResult> Login(string email , string password)
        {
            try
            {
                var token = await _authService.GetJwtToken(email, password);
                if (token != null)
                {
                    return Ok(token);
                }
                return BadRequest("Incorrect username or password");
                
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/SignUp")]
        public async Task<IActionResult> SignUp(SignUpRequest requestDetails)
        {
            try
            {
                var result = await _authService.CreateUser(requestDetails);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
