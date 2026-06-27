using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AprovadosConcursosApi.Domain.Entities.Users;

namespace AprovadosConcursosApi.Application.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Email inválido para geração de token");

            var claims = new List<Claim>
            {
                // ✔ ID padrão .NET
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

                // ✔ Email padrão .NET
                new Claim(ClaimTypes.Email, user.Email),

                // ✔ Role padrão .NET
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var keyString = _config["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(keyString))
                throw new Exception("Jwt:Key não configurado no appsettings");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(keyString)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}