using Microsoft.EntityFrameworkCore;
using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Domain.Interfaces.Repositories;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;

namespace AprovadosConcursosApi.Infrastructure.Repositories
{
    public class BancaRepository : RepositoryBase<Banca>, IBancaRepository
    {
        private readonly AppDbContext _context;

        public BancaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Banca?> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Banca>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Banca>> ObterTodasAsync()
        {
            return await _context.Set<Banca>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Banca?> ObterPorNomeAsync(string nome)
        {
            return await _context.Set<Banca>()
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task AdicionarAsync(Banca entidade)
        {
            await _context.Set<Banca>().AddAsync(entidade);
        }

        public void Atualizar(Banca entidade)
        {
            _context.Set<Banca>().Update(entidade);
        }

        public void Remover(Banca entidade)
        {
            _context.Set<Banca>().Remove(entidade);
        }

    }
}