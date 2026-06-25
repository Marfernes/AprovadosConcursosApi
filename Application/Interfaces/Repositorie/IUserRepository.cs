using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Domain.Entities.Users;

public interface IUserRepository : IRepositoryBase<User>
{
    User? GetByEmail(string email);
}