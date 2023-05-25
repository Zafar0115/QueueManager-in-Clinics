using QueueManager.Application.Abstraction;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override Task<User?> AddAsync(User entity)
        {
            entity.Password = entity.Password.ComputeHash();
            return base.AddAsync(entity);
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
