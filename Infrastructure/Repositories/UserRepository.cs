using AprovadosConcursosApi.Domain.Entities.Users;
using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;

namespace AprovadosConcursosApi.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var resultado =  _context.Users.FirstOrDefault(x => x.Email == email);
            return resultado;
        }
    }
}