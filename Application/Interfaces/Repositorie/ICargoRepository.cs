using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IRepositoryBase<Cargo>
    {
        Task<Cargo?> ObterPorIdAsync(Guid id);
        Task<List<Cargo>> ObterTodosAsync();
        Task<Cargo?> ObterPorNomeAsync(string nome);

        Task AdicionarAsync(Cargo cargo);
        void Atualizar(Cargo cargo);
        void Remover(Cargo cargo);
    }
}