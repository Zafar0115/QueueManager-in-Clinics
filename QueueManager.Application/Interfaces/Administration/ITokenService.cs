using QueueManager.Application.TokenModels;
using System.Security.Claims;

namespace QueueManager.Application.Interfaces.Administration
{
    public interface ITokenService
    {
        public  Task<Token?> GenerateAccessTokensAsync(UserCredentials credentials);
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        public Task<Token?> GenerateRefreshTokens(UserCredentials credentials);
    }
}
