using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BL.DTOs.Login_and_Register;
using RestaurantApp.BL.Managers;

namespace RestaurantApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersManager _usersManagers;
        public UserController(IUsersManager usersManagers)
        {
            _usersManagers = usersManagers;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var result = await _usersManagers.Register(registerDto);

            if (result.IsSuccess)
            {
                return Ok(new { message = "User registered successfully" });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            TokenDto tokenResult = await _usersManagers.Login(loginDto);

            if (tokenResult.Result == TokenResult.Failure)
            {
                return Unauthorized();
            }
            else if (tokenResult.Result == TokenResult.UserpasswordError)
            {
                return BadRequest("Invalid login credentials");
            }

            return tokenResult;
        }
    }
}
