using AprovadosConcursosApi.Application.Dtos.Banca;

namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface IBancaService
    {
        Task<BancaDto> ObterPorIdAsync(Guid id);
        Task<List<BancaDto>> ObterTodasAsync();
        Task<BancaDto> ObterPorNomeAsync(string nome);

        Task<Guid> CriarAsync(CriarBancaDto dto);
        Task AtualizarAsync(AtualizarBancaDto dto);
        Task RemoverAsync(Guid id);
    }
}