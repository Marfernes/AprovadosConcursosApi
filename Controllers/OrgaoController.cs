using AprovadosConcursosApi.Application.Dtos.Orgao;
using AprovadosConcursosApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AprovadosConcursosApi.Controllers
{
    [ApiController]
    [Route("api/orgaos")]
    public class OrgaoController : ControllerBase
    {
        private readonly IOrgaoService _service;

        public OrgaoController(IOrgaoService service)
        {
            _service = service;
        }

        //Apenas Admin pode cadastrar
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrgaoDto dto)
        {
            var id = await _service.CadastrarAsync(dto);
            return Ok(new { id, message = "Órgão criado com sucesso" });
        }

        //Apenas Admin pode atualizar
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrgaoDto dto)
        {
            await _service.AtualizarAsync(dto);
            return Ok(new { message = "Órgão atualizado com sucesso" });
        }

        // Apenas Admin pode excluir
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.ExcluirAsync(id);
            return Ok(new { message = "Órgão excluído com sucesso" });
        }

        //Qualquer usuário autenticado pode ver
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var orgao = await _service.ObterPorIdAsync(id);

            if (orgao == null)
                return NotFound();

            return Ok(orgao);
        }

        //Lista todos
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.ObterTodosAsync();
            return Ok(lista);
        }

        //Busca por nome
        [Authorize]
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            var lista = await _service.BuscarPorNomeAsync(nome);
            return Ok(lista);
        }

        //Apenas ativos
        [Authorize]
        [HttpGet("ativos")]
        public async Task<IActionResult> Ativos()
        {
            var lista = await _service.ObterAtivosAsync();
            return Ok(lista);
        }
    }
}