using AprovadosConcursosApi.Application.Dtos.Orgao;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface IOrgaoService
    {
        Task<Guid> CadastrarAsync(CreateOrgaoDto dto);

        Task AtualizarAsync(UpdateOrgaoDto dto);

        Task ExcluirAsync(Guid id);

        Task<Orgao?> ObterPorIdAsync(Guid id);

        Task<IEnumerable<Orgao>> ObterTodosAsync();

        Task<IEnumerable<Orgao>> BuscarPorNomeAsync(string nome);

        Task<IEnumerable<Orgao>> ObterAtivosAsync();

        Task<bool> ExistePorNomeAsync(string nome);
    }
}