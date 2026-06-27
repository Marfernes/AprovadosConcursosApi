using AprovadosConcursosApi.Application.Dtos.Orgao;
using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Domain.Entities;

namespace AprovadosConcursosApi.Application.Services
{
    public class OrgaoService : IOrgaoService
    {
        private readonly IOrgaoRepository _repository;

        public OrgaoService(IOrgaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CadastrarAsync(CreateOrgaoDto dto)
        {
            var existe = await _repository.ExistePorNomeAsync(dto.Nome);

            if (existe)
                throw new Exception("Já existe um órgão com esse nome");

            var orgao = new Orgao
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Sigla = dto.Sigla,
                Site = dto.Site,
                Ativo = true,
                DataCadastro = DateTime.UtcNow
            };

            await _repository.AddAsync(orgao);
            await _repository.SaveChangesAsync();

            return orgao.Id;
        }

        public async Task AtualizarAsync(UpdateOrgaoDto dto)
        {
            var orgao = await _repository.GetByIdAsync(dto.Id);

            if (orgao == null)
                throw new Exception("Órgão não encontrado");

            orgao.Nome = dto.Nome;
            orgao.Sigla = dto.Sigla;
            orgao.Site = dto.Site;
            orgao.Ativo = dto.Ativo;

            await _repository.UpdateAsync(orgao);
            await _repository.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var orgao = await _repository.GetByIdAsync(id);

            if (orgao == null)
                throw new Exception("Órgão não encontrado");

            await _repository.DeleteAsync(orgao);
            await _repository.SaveChangesAsync();
        }

        public async Task<Orgao?> ObterPorIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Orgao>> ObterTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Orgao>> BuscarPorNomeAsync(string nome)
        {
            return await _repository.BuscarPorNomeAsync(nome);
        }

        public async Task<IEnumerable<Orgao>> ObterAtivosAsync()
        {
            return await _repository.ObterAtivosAsync();
        }

        public async Task<bool> ExistePorNomeAsync(string nome)
        {
            return await _repository.ExistePorNomeAsync(nome);
        }
    }
}