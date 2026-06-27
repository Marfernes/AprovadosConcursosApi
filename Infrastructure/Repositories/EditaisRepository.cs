using AprovadosConcursosApi.Domain.Entities;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;
using AprovadosConcursosApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class EditalRepository : RepositoryBase<Edital>, IEditalRepository
{
    private readonly AppDbContext _context;

    public EditalRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Edital>> ObterTodosComPaginacao(int pagina, int quantidade)
    {
        return await _context.Editais
            .OrderByDescending(x => x.DataCadastro)
            .Skip((pagina - 1) * quantidade)
            .Take(quantidade)
            .ToListAsync();
    }

    public async Task<IEnumerable<Edital>> BuscarPorTitulo(string titulo)
    {
        return await _context.Editais
            .Where(x => x.Titulo.Contains(titulo))
            .OrderBy(x => x.Titulo)
            .ToListAsync();
    }

    public async Task<bool> ExisteTitulo(string titulo)
    {
        return await _context.Editais
            .AnyAsync(x => x.Titulo == titulo);
    }

    public async Task<int> ObterTotalRegistros()
    {
        return await _context.Editais.CountAsync();
    }

    public async Task<IEnumerable<Edital>> ObterTodosComRelacionamentosAsync()
    {
        return await _context.Editais
         .Include(x => x.Orgao)
         .Include(x => x.Banca)
         .Include(x => x.Cargo)
         .OrderByDescending(x => x.DataCadastro)
         .ToListAsync();
    }

    public async Task<Edital?> ObterPorIdComRelacionamentosAsync(Guid id)
    {
        return await _context.Editais
       .Include(x => x.Orgao)
       .Include(x => x.Banca)
       .Include(x => x.Cargo)
       .FirstOrDefaultAsync(x => x.Id == id);
    }
}