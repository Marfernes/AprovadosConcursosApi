using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.Cargos;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/cargos")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = await _cargoService.ObterPorIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _cargoService.ObterTodosAsync();
            return Ok(result);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> ObterPorNome(string nome)
        {
            var result = await _cargoService.ObterPorNomeAsync(nome);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCargoDto dto)
        {
            var id = await _cargoService.CriarAsync(dto);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCargoDto dto)
        {
            await _cargoService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _cargoService.RemoverAsync(id);
            return NoContent();
        }
    }
}