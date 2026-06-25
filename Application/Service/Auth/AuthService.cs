using AprovadosConcursosApi.Application.Dtos.Login;
using AprovadosConcursosApi.Application.Interfaces;
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

        public string Login(LoginRequestDto request)
        {
            var user = BuscarUsuario(request.Email);

            ValidarUsuario(user, request.Password);

            return GerarToken(user);
        }

        //busca usuário
        private User BuscarUsuario(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        // valida login
        private void ValidarUsuario(User user, string password)
        {
            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (user.PasswordHash != password)
                throw new Exception("Senha inválida");
        }

        // gera token
        private string GerarToken(User user)
        {
            return _tokenService.GenerateToken(user);
        }
    }
}