using AprovadosConcursosApi.Application.Dtos.Login;
using AprovadosConcursosApi.Domain.Entities.Login;

namespace AprovadosConcursosApi.Application.Interfaces
{
    public interface IAuthService
    {
       LoginResponse Login(LoginRequestDto request);
    }
}