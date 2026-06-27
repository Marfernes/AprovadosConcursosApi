using AprovadosConcursosApi.Domain.Interfaces;
using AprovadosConcursosApi.Domain.Interfaces.IUnitOfWork;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;

namespace AprovadosConcursosApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}