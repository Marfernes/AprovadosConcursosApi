using Microsoft.AspNetCore.Mvc;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.Banca;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/bancas")]
    public class BancaController : ControllerBase
    {
        private readonly IBancaService _bancaService;

        public BancaController(IBancaService bancaService)
        {
            _bancaService = bancaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = await _bancaService.ObterPorIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas()
        {
            var result = await _bancaService.ObterTodasAsync();
            return Ok(result);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> ObterPorNome(string nome)
        {
            var result = await _bancaService.ObterPorNomeAsync(nome);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarBancaDto dto)
        {
            var id = await _bancaService.CriarAsync(dto);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarBancaDto dto)
        {
            await _bancaService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _bancaService.RemoverAsync(id);
            return NoContent();
        }
    }
}