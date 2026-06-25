using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Application.Dtos.User;
using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(CreateUserDto dto)
        {
            var userExists = _userRepository.GetByEmail(dto.Email);

            if (userExists != null)
                throw new Exception("Usuário já existe");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = dto.Password, // depois vamos trocar por BCrypt
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();

            return user;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateRole(Guid id, string role)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            user.Role = role;

            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            _userRepository.Delete(user);
            _userRepository.SaveChanges();
        }
    }
}