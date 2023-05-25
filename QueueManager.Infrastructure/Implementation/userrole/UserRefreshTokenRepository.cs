using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<UserRefreshToken?> AddAsync(UserRefreshToken entity)
        {
            UserRefreshToken? userRefreshToken = _dbContext.UserRefreshTokens
                .FirstOrDefault(o => o.UserId == entity.UserId);
            if (userRefreshToken is null)
            {
                return await base.AddAsync(entity);
            }
            else
            {
                return await base.UpdateAsync(entity);
            }
        }
    }
}
