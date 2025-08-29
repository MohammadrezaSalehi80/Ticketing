using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IUserServices userServices, 
            IJwtTokenService jwtTokenService,
            IPasswordHasher passwordHasher
            )
        {
            _userServices = userServices;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userServices.GetUserByEmail(loginDto.Email);
            if (user == null) 
                return Unauthorized("User Not Found");

            if (!_passwordHasher.VerifyPassword(loginDto.Password, user.Password))
                return Unauthorized("The password is incorrect");

            return Ok(_jwtTokenService.GeneratJwtToken(new UserDto()
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                Role = user.Role.ToString()
            }));
        }
    }
}
