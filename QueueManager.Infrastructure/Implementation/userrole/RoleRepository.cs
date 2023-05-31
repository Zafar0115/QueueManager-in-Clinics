using Microsoft.EntityFrameworkCore;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Role?> AddAsync(Role entity)
        {
            _dbContext.Roles.Attach(entity);
           await _dbContext.SaveChangesAsync();
            return entity;
        }
        public override  Task<Role?> GetById(Guid id)
        {
            IEnumerable<Role> roles=_dbContext.Roles.Include(x => x.Permissions).ToList();
            Role? role = roles.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(role);
        }
        public override Task<IQueryable<Role>> GetAll()
        {
            return Task.FromResult(_dbContext.Roles.AsQueryable());
        }

        public override Task<Role?> UpdateAsync(Role entity)
        {
            return base.UpdateAsync(entity);
        }


    }
}
