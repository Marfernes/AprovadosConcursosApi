using Microsoft.EntityFrameworkCore;
using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Infrastructure.Data.ContextBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}