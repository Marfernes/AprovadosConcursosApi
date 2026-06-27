using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Domain.Interfaces.Repositories;
using AprovadosConcursosApi.Domain.Interfaces;
using AprovadosConcursosApi.Application.Dtos.Cargos;
using AprovadosConcursosApi.Domain.Interfaces.IUnitOfWork;

namespace AprovadosConcursosApi.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CargoService(ICargoRepository cargoRepository, IUnitOfWork unitOfWork)
        {
            _cargoRepository = cargoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CargoDto?> ObterPorIdAsync(Guid id)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(id);

            if (cargo == null) return null;

            return new CargoDto
            {
                Id = cargo.Id,
                Nome = cargo.Nome,
                Ativo = cargo.Ativo,
                DataCadastro = cargo.DataCadastro
            };
        }

        public async Task<List<CargoDto>> ObterTodosAsync()
        {
            var cargos = await _cargoRepository.ObterTodosAsync();

            return cargos.Select(x => new CargoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Ativo = x.Ativo,
                DataCadastro = x.DataCadastro
            }).ToList();
        }

        public async Task<CargoDto?> ObterPorNomeAsync(string nome)
        {
            var cargo = await _cargoRepository.ObterPorNomeAsync(nome);

            if (cargo == null) return null;

            return new CargoDto
            {
                Id = cargo.Id,
                Nome = cargo.Nome,
                Ativo = cargo.Ativo,
                DataCadastro = cargo.DataCadastro
            };
        }

        public async Task<Guid> CriarAsync(CriarCargoDto dto)
        {
            var cargo = new Cargo
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Ativo = true,
                DataCadastro = DateTime.UtcNow
            };

            await _cargoRepository.AdicionarAsync(cargo);
            await _unitOfWork.CommitAsync();

            return cargo.Id;
        }

        public async Task AtualizarAsync(AtualizarCargoDto dto)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(dto.Id);

            if (cargo == null)
                throw new Exception("Cargo não encontrado");

            cargo.Nome = dto.Nome;
            cargo.Ativo = dto.Ativo;

            _cargoRepository.Atualizar(cargo);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(id);

            if (cargo == null)
                throw new Exception("Cargo não encontrado");

            _cargoRepository.Remover(cargo);
            await _unitOfWork.CommitAsync();
        }
    }
}