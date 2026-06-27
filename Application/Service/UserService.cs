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

        public async Task<User> CreateAsync(CreateUserDto dto)
        {
            var userExists = await _userRepository.GetByEmailAsync(dto.Email);

            if (userExists != null)
                throw new Exception("Usuário já existe");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = dto.Password, // depois BCrypt
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateRoleAsync(Guid id, string role)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            user.Role = role;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
        }

    }
}