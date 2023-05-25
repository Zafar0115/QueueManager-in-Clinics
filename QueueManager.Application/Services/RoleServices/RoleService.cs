using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services.role_services
{
    public class RoleService:IRoleRepository
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role?> AddAsync(Role entity)
        {
           return await _roleRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Role>?> AddRangeAsync(IEnumerable<Role> entities)
        {
            return await _roleRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<Role>> Get(Expression<Func<Role, bool>>? expression = null)
        {
            return await _roleRepository.Get(expression);
        }

        public async Task<IQueryable<Role>> GetAll()
        {
            return await _roleRepository.GetAll();
        }

        public async Task<Role?> GetById(Guid id)
        {
            return await _roleRepository.GetById(id);
        }

        public async Task<Role?> RemoveAsync(Guid id)
        {
            return await _roleRepository.RemoveAsync(id);
        }

        public async Task<Role?> UpdateAsync(Role entity)
        {
            return await _roleRepository.UpdateAsync(entity);
        }
    }
}
