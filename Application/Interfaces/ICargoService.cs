using AprovadosConcursosApi.Application.Dtos.Cargos;

namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface ICargoService
    {
        Task<CargoDto?> ObterPorIdAsync(Guid id);
        Task<List<CargoDto>> ObterTodosAsync();
        Task<CargoDto?> ObterPorNomeAsync(string nome);

        Task<Guid> CriarAsync(CriarCargoDto dto);
        Task AtualizarAsync(AtualizarCargoDto dto);
        Task RemoverAsync(Guid id);
    }
}