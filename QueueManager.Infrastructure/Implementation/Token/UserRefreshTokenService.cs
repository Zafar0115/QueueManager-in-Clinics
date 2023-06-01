
using AutoMapper.Configuration.Conventions;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.TokenModels;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.JwtTokenHandler.Handlers
{
    public class UserRefreshTokenService :  IUserRefreshTokenService
    {
        private readonly IApplicationDbContext _dbContext;

        public UserRefreshTokenService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserRefreshToken?> AddUserRefreshToken(UserRefreshToken user)
        {
            var entry=await _dbContext.UserRefreshTokens.AddAsync(user);
            return entry.Entity;
        }

        public  Task<UserRefreshToken> DeleteUserRefreshToken(UserRefreshToken user)
        {
            var entry = _dbContext.UserRefreshTokens.Remove(user);
            return Task.FromResult(entry.Entity);
        }

        public Task<UserRefreshToken?> GetSavedRefreshToken(UserCredentials credentials)
        {
            UserRefreshToken? user = _dbContext.UserRefreshTokens
                .FirstOrDefault(o => o.User.UserName == credentials.UserName);
            return Task.FromResult(user);
        }
    }
}
