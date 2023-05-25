using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.role;
using QueueManager.Domain.Models.UserModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services.role_services
{
    public class UserService:IUserRepository
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> AddAsync(User entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<User>?> AddRangeAsync(IEnumerable<User> entities)
        {
            return await _userRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<User>> Get(Expression<Func<User, bool>>? expression = null)
        {
            return await _userRepository.Get(expression);
        }

        public async Task<IQueryable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User?> GetById(Guid id)
        {
           return await _userRepository.GetById(id);
        }

        public async Task<User?> RemoveAsync(Guid id)
        {
            return await _userRepository.RemoveAsync(id);
        }

        public async Task<User?> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
