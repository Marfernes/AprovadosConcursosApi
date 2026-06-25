using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Application.Dtos.UserRole;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound("Usuário não encontrado");

            return Ok(user);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/role")]
        public IActionResult UpdateRole(Guid id, UpdateUserRoleDto dto)
        {
            _userService.UpdateRole(id, dto.Role);
            return Ok("Role atualizada com sucesso");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok("Usuário removido");
        }
    }
}