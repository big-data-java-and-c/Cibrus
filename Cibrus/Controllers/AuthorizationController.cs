using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cibrus.Services;
using Cibrus.models;

namespace Cibrus.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IUserService userService;

        public AuthorizationController(IUserService _userService)
        {
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult Authenticate([FromBody] LoginForm loginForm)
        {
            var token = userService.Authenticate(loginForm.email, loginForm.password);

            if (token == null) { return BadRequest(new { message = "Email lub haslo jest niepoprawne" }); }

            return Ok(token);
        }

        [HttpPost("signup")]
        public IActionResult register([FromBody] SignUpForm userToRegister)
        {
            if (userToRegister != null)
            {
                if (!userService.checkIfUserExists(userToRegister.email))
                {
                    userService.addUser(userToRegister);
                    return Ok(userToRegister);
                }
                else { return BadRequest(new { message = "email jest juz zajety" }); }
            }
            else { return BadRequest(new { message = "Wartosci sa puste, prosze wpisac login i haslo" }); }
        }
    }
}
