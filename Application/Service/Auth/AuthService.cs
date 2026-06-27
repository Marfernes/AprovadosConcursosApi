using AprovadosConcursosApi.Application.Dtos.Login;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Domain.Entities.Login;
using AprovadosConcursosApi.Domain.Entities.Users;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;

namespace AprovadosConcursosApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        public AuthService(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public LoginResponse Login(LoginRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new Exception("Email inválido");

            if (string.IsNullOrWhiteSpace(request.Password))
                throw new Exception("Senha inválida");

            var user = BuscarUsuario(request.Email);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new Exception("Usuário sem senha cadastrada");

            if (user.PasswordHash.Trim() != request.Password.Trim())
                throw new Exception("Senha inválida");

            var token = GerarToken(user);

            if (string.IsNullOrWhiteSpace(user.Role))
                user.Role = "User";

            return new LoginResponse
            {
                Token = token,
                Role = user.Role
            };
        }
        // =========================
        // BUSCA USUÁRIO
        // =========================
        private User BuscarUsuario(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        // =========================
        // VALIDA LOGIN
        // =========================
        private void ValidarUsuario(User user, string password)
        {
            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Senha inválida");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new Exception("Senha não configurada no banco");

            //versão simples (MVP atual)
            if (user.PasswordHash != password)
                throw new Exception("Senha inválida");

            // SEGURANÇA FUTURA (RECOMENDADO):
            // if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            //     throw new Exception("Senha inválida");
        }

        // =========================
        // GERA TOKEN
        // =========================
        private string GerarToken(User user)
        {
            //garante role padrão (evita crash no TokenService)
            if (string.IsNullOrWhiteSpace(user.Role))
                user.Role = "User";

            return _tokenService.GenerateToken(user);
        }

    }
}