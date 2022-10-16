using MinimalCatalogoApi.Models;

namespace MinimalCatalogoApi.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);
    }
}
