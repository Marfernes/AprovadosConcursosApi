using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Application.Dtos.Login;
using Microsoft.AspNetCore.Authorization;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _authService.Login(request);

                return Ok(new
                {
                    token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}