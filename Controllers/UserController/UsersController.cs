using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Application.Dtos.UserRole;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound("Usuário não encontrado");

            return Ok(user);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/role")]
        public async Task<IActionResult> UpdateRole(Guid id, UpdateUserRoleDto dto)
        {
            await _userService.UpdateRoleAsync(id, dto.Role);
            return Ok("Role atualizada com sucesso");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok("Usuário removido");
        }
    }
}