using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Car.API.Repository;
using Car.API.Model;
using Car.API.DTO;

namespace Car.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto loginModel)
        {
            if (await _loginService.ValidateCredentialsAsync(loginModel))
            {
                return Ok("Authentication successful"); // Return any necessary data
            }
            else
            {
                return Unauthorized("Invalid credentials"); // Or any other appropriate response
            }
        }
    }
}
