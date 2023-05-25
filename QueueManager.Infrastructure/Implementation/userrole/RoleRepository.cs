using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
