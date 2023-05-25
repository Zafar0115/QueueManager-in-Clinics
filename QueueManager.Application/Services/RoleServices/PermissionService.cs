using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services.role_services
{
    public class PermissionService:IPermissionRepository
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission?> AddAsync(Permission entity)
        {
            return await _permissionRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Permission>?> AddRangeAsync(IEnumerable<Permission> entities)
        {
            return await _permissionRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<Permission>> Get(Expression<Func<Permission, bool>>? expression = null)
        {
            return await _permissionRepository.Get(expression);
        }

        public async Task<IQueryable<Permission>> GetAll()
        {
            return await _permissionRepository.GetAll();
        }

        public async Task<Permission?> GetById(Guid id)
        {
            return await _permissionRepository.GetById(id);
        }

        public async Task<Permission?> RemoveAsync(Guid id)
        {
            return await _permissionRepository.RemoveAsync(id);
        }

        public async Task<Permission?> UpdateAsync(Permission entity)
        {
            return await _permissionRepository.UpdateAsync(entity);
        }
    }
}
