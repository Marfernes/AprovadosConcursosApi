using Microsoft.EntityFrameworkCore;
using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Domain.Interfaces.Repositories;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;

namespace AprovadosConcursosApi.Infrastructure.Repositories
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        private readonly AppDbContext _context;

        public CargoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cargo?> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Cargo>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Cargo>> ObterTodosAsync()
        {
            return await _context.Set<Cargo>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cargo?> ObterPorNomeAsync(string nome)
        {
            return await _context.Set<Cargo>()
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task AdicionarAsync(Cargo cargo)
        {
            await _context.Set<Cargo>().AddAsync(cargo);
        }

        public void Atualizar(Cargo cargo)
        {
            _context.Set<Cargo>().Update(cargo);
        }

        public void Remover(Cargo cargo)
        {
            _context.Set<Cargo>().Remove(cargo);
        }
    }
}