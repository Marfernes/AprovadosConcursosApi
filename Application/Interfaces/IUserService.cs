using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface IUserService
    {
        User Create(CreateUserDto dto);

        List<User> GetAll();

        User? GetById(Guid id);

        void UpdateRole(Guid id, string role);

        void Delete(Guid id);
    }
}