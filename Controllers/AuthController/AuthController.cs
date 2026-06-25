using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Application.Dtos.Login;
using Microsoft.AspNetCore.Authorization;
using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Application.Interfaces.Services;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;


        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
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

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDto dto)
        {
            var user = _userService.Create(dto);

            return Ok(new
            {
                message = "Usuário criado com sucesso",
                user.Id,
                user.Email
            });
        }
    }
}