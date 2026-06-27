using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities;

public interface IOrgaoRepository : IRepositoryBase<Orgao>
{
    Task<List<Orgao>> BuscarPorNomeAsync(string nome);

    Task<bool> ExistePorNomeAsync(string nome);

    Task<List<Orgao>> ObterAtivosAsync();
}