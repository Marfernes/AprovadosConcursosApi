using AprovadosConcursosApi.Application.Dtos.Login;

namespace AprovadosConcursosApi.Application.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginRequest request);
    }
}