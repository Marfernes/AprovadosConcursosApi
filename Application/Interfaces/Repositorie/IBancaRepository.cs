using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Domain.Interfaces.Repositories
{
    public interface IBancaRepository : IRepositoryBase<Banca>
    {
        Task<Banca?> ObterPorIdAsync(Guid id);

        Task<List<Banca>> ObterTodasAsync();

        Task<Banca?> ObterPorNomeAsync(string nome);

        Task AdicionarAsync(Banca entidade);

        void Atualizar(Banca entidade);

        void Remover(Banca entidade);
    }
}