using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<User?> AddAsync(User entity)
        {
            entity.Password = entity.Password.ComputeHash();
            _dbContext.Users.Attach(entity);

            return (await _dbContext.SaveChangesAsync()) > 0 ? entity : null;
        }
        public override Task<IEnumerable<User>?> AddRangeAsync(IEnumerable<User> entities)
        {
            foreach (var entity in entities)
            {
                entity.Password = entity.Password.ComputeHash();
            }
            return base.AddRangeAsync(entities);
        }
       
        public override Task<User?> UpdateAsync(User entity)
        {
            entity.Password=entity.Password.ComputeHash();
            return base.UpdateAsync(entity);
        }
    }
}
