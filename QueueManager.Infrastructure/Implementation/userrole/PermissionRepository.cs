using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
