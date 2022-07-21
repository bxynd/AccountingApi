using Application.Dto;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInUserDto signInUserDto)
        {
            var user = await _userService.GetByEmail(signInUserDto.Email);
            if (user == null)
            {
                return BadRequest("Check credentials");
            }

            if (!user.Password.Equals(signInUserDto.Password))
            {
                return BadRequest("Check credentials");
            }

            var secretKey = _configuration.GetSection("TokenSettings:Token").Value;
            return Ok(TokenService.CreateToken(user,secretKey));
        }
    }
}
