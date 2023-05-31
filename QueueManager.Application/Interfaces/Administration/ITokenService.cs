using QueueManager.Application.TokenModels;
using System.Security.Claims;

namespace QueueManager.Application.Interfaces.Administration
{
    public interface ITokenService
    {
        public  Task<Token?> GenerateAccessTokenAsync(UserCredentials credentials);
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
