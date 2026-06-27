using AprovadosConcursosApi.Application.Dtos.Edital;
using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Application.Services
{
    public class EditalService : IEditalService
    {
        private readonly IEditalRepository _editalRepository;

        public EditalService(IEditalRepository editalRepository)
        {
            _editalRepository = editalRepository;
        }

        public async Task<Guid> CadastrarAsync(CreateEditalDto dto)
        {
            var existeTitulo = await _editalRepository.ExisteTitulo(dto.Titulo);

            if (existeTitulo)
                throw new Exception("Já existe um edital com esse título.");

            var edital = new Edital
            {
                Id = Guid.NewGuid(),
                Titulo = dto.Titulo,
                NumeroEdital = dto.NumeroEdital,
                QuantidadeVagas = dto.QuantidadeVagas,
                Salario = dto.Salario,
                DataPublicacao = dto.DataPublicacao,
                DataInscricaoInicio = dto.DataInscricaoInicio,
                DataInscricaoFim = dto.DataInscricaoFim,
                DataProva = dto.DataProva,
                LinkEdital = dto.LinkEdital,
                OrgaoId = dto.OrgaoId,
                BancaId = dto.BancaId,
                CargoId = dto.CargoId,
                Ativo = true,
                DataCadastro = DateTime.UtcNow
            };

            await _editalRepository.AddAsync(edital);
            await _editalRepository.SaveChangesAsync();

            return edital.Id;
        }

        public async Task AtualizarAsync(UpdateEditalDto dto)
        {
            var edital = await _editalRepository.GetByIdAsync(dto.Id);

            if (edital == null)
                throw new Exception("Edital não encontrado.");

            edital.Titulo = dto.Titulo;
            edital.NumeroEdital = dto.NumeroEdital;
            edital.QuantidadeVagas = dto.QuantidadeVagas;
            edital.Salario = dto.Salario;
            edital.DataPublicacao = dto.DataPublicacao;
            edital.DataInscricaoInicio = dto.DataInscricaoInicio;
            edital.DataInscricaoFim = dto.DataInscricaoFim;
            edital.DataProva = dto.DataProva;
            edital.LinkEdital = dto.LinkEdital;
            edital.OrgaoId = dto.OrgaoId;
            edital.BancaId = dto.BancaId;
            edital.CargoId = dto.CargoId;
            edital.Ativo = dto.Ativo;

            await _editalRepository.UpdateAsync(edital);
            await _editalRepository.SaveChangesAsync();
        }

        public async Task<EditalDto?> ObterPorIdAsync(Guid id)
        {
            var edital = await _editalRepository.ObterPorIdComRelacionamentosAsync(id);

            if (edital == null)
                return null;

            return new EditalDto
            {
                Id = edital.Id,
                Titulo = edital.Titulo,
                NumeroEdital = edital.NumeroEdital,
                QuantidadeVagas = edital.QuantidadeVagas,
                Salario = edital.Salario,
                DataPublicacao = edital.DataPublicacao,
                DataInscricaoInicio = edital.DataInscricaoInicio,
                DataInscricaoFim = edital.DataInscricaoFim,
                DataProva = edital.DataProva,
                LinkEdital = edital.LinkEdital,
                Orgao = edital.Orgao?.Nome ?? string.Empty,
                Banca = edital.Banca?.Nome ?? string.Empty,
                Cargo = edital.Cargo?.Nome ?? string.Empty,
                Ativo = edital.Ativo
            };
        }

        public async Task<IEnumerable<EditalDto>> ObterTodosAsync()
        {
            var editais = await _editalRepository.ObterTodosComRelacionamentosAsync();

            return editais.Select(edital => new EditalDto
            {
                Id = edital.Id,
                Titulo = edital.Titulo,
                NumeroEdital = edital.NumeroEdital,
                QuantidadeVagas = edital.QuantidadeVagas,
                Salario = edital.Salario,
                DataPublicacao = edital.DataPublicacao,
                DataInscricaoInicio = edital.DataInscricaoInicio,
                DataInscricaoFim = edital.DataInscricaoFim,
                DataProva = edital.DataProva,
                LinkEdital = edital.LinkEdital,
                Orgao = edital.Orgao?.Nome ?? string.Empty,
                Banca = edital.Banca?.Nome ?? string.Empty,
                Cargo = edital.Cargo?.Nome ?? string.Empty,
                Ativo = edital.Ativo
            });
        }

        public async Task ExcluirAsync(Guid id)
        {
            var edital = await _editalRepository.GetByIdAsync(id);

            if (edital == null)
                throw new Exception("Edital não encontrado.");

            await _editalRepository.DeleteAsync(edital);
            await _editalRepository.SaveChangesAsync();
        }
    }
}