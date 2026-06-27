using AprovadosConcursosApi.Application.Dtos.Edital;

public interface IEditalService
{
    Task<Guid> CadastrarAsync(CreateEditalDto dto);

    Task AtualizarAsync(UpdateEditalDto dto);

    Task<EditalDto?> ObterPorIdAsync(Guid id);

    Task<IEnumerable<EditalDto>> ObterTodosAsync();

    Task ExcluirAsync(Guid id);
}