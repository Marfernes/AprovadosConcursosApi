using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Application.Interfaces.Repositorie
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}