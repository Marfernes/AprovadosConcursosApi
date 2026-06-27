using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities;

public interface IEditalRepository : IRepositoryBase<Edital>
{
    Task<IEnumerable<Edital>> ObterTodosComRelacionamentosAsync();
    Task<Edital?> ObterPorIdComRelacionamentosAsync(Guid id);
    Task<IEnumerable<Edital>> ObterTodosComPaginacao(int pagina, int quantidade);

    Task<IEnumerable<Edital>> BuscarPorTitulo(string titulo);

    Task<bool> ExisteTitulo(string titulo);

    Task<int> ObterTotalRegistros();
}