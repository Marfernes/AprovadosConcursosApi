using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;
using Microsoft.EntityFrameworkCore;

namespace AprovadosConcursosApi.Infrastructure.Repositories
{
    public class OrgaoRepository : RepositoryBase<Orgao>, IOrgaoRepository
    {
        private readonly AppDbContext _context;

        public OrgaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Orgao>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Orgaos
                .Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<bool> ExistePorNomeAsync(string nome)
        {
            return await _context.Orgaos
                .AnyAsync(x => x.Nome.ToLower() == nome.ToLower());
        }

        public async Task<List<Orgao>> ObterAtivosAsync()
        {
            return await _context.Orgaos
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
    }
}