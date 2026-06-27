using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Application.Dtos.Login;
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

        // =========================
        // LOGIN
        // =========================
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            var result = _authService.Login(request);

            return Ok(new
            {
                message = "Login realizado com sucesso",
                role = result.Role,
                token = result.Token
            });
        }

        // =========================
        // ME (JWT via Authorization Header)
        // =========================
        [HttpGet("me")]
        public IActionResult Me()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader))
                return Unauthorized();

            var token = authHeader.Replace("Bearer ", "");

            try
            {
                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                var id = jwt.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;
                var email = jwt.Claims.FirstOrDefault(x => x.Type.Contains("email"))?.Value;
                var role = jwt.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value;

                return Ok(new
                {
                    id,
                    email,
                    role
                });
            }
            catch
            {
                return Unauthorized();
            }
        }

        // =========================
        // LOGOUT
        // =========================
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new
            {
                message = "Logout realizado com sucesso"
            });
        }

        // =========================
        // REGISTER
        // =========================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto);

            return Ok(new
            {
                message = "Usuário criado com sucesso",
                user.Id,
                user.Email
            });
        }
    }
}