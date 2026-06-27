using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.Edital;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/editais")]
    [Authorize]
    public class EditalController : ControllerBase
    {
        private readonly IEditalService _editalService;

        public EditalController(IEditalService editalService)
        {
            _editalService = editalService;
        }

        // =========================
        // CREATE
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEditalDto dto)
        {
            try
            {
                var id = await _editalService.CadastrarAsync(dto);

                return Ok(new
                {
                    message = "Edital criado com sucesso",
                    id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // =========================
        // GET ALL
        // (caso queira liberar depois, remova o authorize do controller e coloque só nos métodos de escrita)
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var editais = await _editalService.ObterTodosAsync();
            return Ok(editais);
        }

        // =========================
        // GET BY ID
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var edital = await _editalService.ObterPorIdAsync(id);

            if (edital == null)
                return NotFound(new { message = "Edital não encontrado" });

            return Ok(edital);
        }

        // =========================
        // UPDATE
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEditalDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest(new
                    {
                        message = "ID da URL diferente do body"
                    });
                }

                await _editalService.AtualizarAsync(dto);

                return Ok(new
                {
                    message = "Edital atualizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // =========================
        // DELETE
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _editalService.ExcluirAsync(id);

                return Ok(new
                {
                    message = "Edital deletado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}