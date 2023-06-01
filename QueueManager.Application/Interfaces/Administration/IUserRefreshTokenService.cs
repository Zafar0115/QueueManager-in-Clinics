using QueueManager.Application.TokenModels;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.Interfaces.Administration
{
    public interface IUserRefreshTokenService
    {
        Task<UserRefreshToken?> AddUserRefreshToken(UserRefreshToken user);
        Task<UserRefreshToken> DeleteUserRefreshToken(UserRefreshToken user);
        Task<UserRefreshToken?> GetSavedRefreshToken(UserCredentials credentials);
    }
}
