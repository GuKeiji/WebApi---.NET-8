using Fiap.Api.Alertas.Models;

namespace Fiap.Api.Alertas.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}
