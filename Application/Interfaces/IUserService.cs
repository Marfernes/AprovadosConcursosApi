using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto dto);

        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(Guid id);

        Task UpdateRoleAsync(Guid id, string role);

        Task DeleteAsync(Guid id);
    }
}