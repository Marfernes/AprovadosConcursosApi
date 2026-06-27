using AprovadosConcursosApi.Application.Dtos.Banca;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Domain.Interfaces.IUnitOfWork;
using AprovadosConcursosApi.Domain.Interfaces.Repositories;

namespace AprovadosConcursosApi.Application.Services
{
    public class BancaService : IBancaService
    {
        private readonly IBancaRepository _bancaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BancaService(IBancaRepository bancaRepository, IUnitOfWork unitOfWork)
        {
            _bancaRepository = bancaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BancaDto> ObterPorIdAsync(Guid id)
        {
            var banca = await _bancaRepository.ObterPorIdAsync(id);

            if (banca == null)
                return null;

            return new BancaDto
            {
                Id = banca.Id,
                Nome = banca.Nome
            };
        }

        public async Task<List<BancaDto>> ObterTodasAsync()
        {
            var bancas = await _bancaRepository.ObterTodasAsync();

            return bancas.Select(x => new BancaDto
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();
        }

        public async Task<BancaDto> ObterPorNomeAsync(string nome)
        {
            var banca = await _bancaRepository.ObterPorNomeAsync(nome);

            if (banca == null)
                return null;

            return new BancaDto
            {
                Id = banca.Id,
                Nome = banca.Nome
            };
        }

        public async Task<Guid> CriarAsync(CriarBancaDto dto)
        {
            var banca = new Banca
            {
                Nome = dto.Nome
            };

            await _bancaRepository.AdicionarAsync(banca);
            await _unitOfWork.CommitAsync();

            return banca.Id;
        }

        public async Task AtualizarAsync(AtualizarBancaDto dto)
        {
            var banca = await _bancaRepository.ObterPorIdAsync(dto.Id);

            if (banca == null)
                throw new Exception("Banca não encontrada");

            banca.Nome = dto.Nome;

            _bancaRepository.Atualizar(banca);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var banca = await _bancaRepository.ObterPorIdAsync(id);

            if (banca == null)
                throw new Exception("Banca não encontrada");

            _bancaRepository.Remover(banca);
            await _unitOfWork.CommitAsync();
        }
    }
}