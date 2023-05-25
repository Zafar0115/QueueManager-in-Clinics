using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services
{
    public class WaitlistService:IWaitlistRepository
    {
        private readonly IWaitlistRepository _waitlistRepository;

        public WaitlistService(IWaitlistRepository waitlistRepository)
        {
            _waitlistRepository = waitlistRepository;
        }

        public async Task<WaitList?> AddAsync(WaitList entity)
        {
            return await _waitlistRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<WaitList>?> AddRangeAsync(IEnumerable<WaitList> entities)
        {
            return await  _waitlistRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<WaitList>> Get(Expression<Func<WaitList, bool>>? expression = null)
        {
            return await _waitlistRepository.Get(expression);
        }

        public async Task<IQueryable<WaitList>> GetAll()
        {
            return await _waitlistRepository.GetAll();
        }

        public async Task<WaitList?> GetById(Guid id)
        {
            return await _waitlistRepository.GetById(id);
        }

        public async Task<WaitList?> RemoveAsync(Guid id)
        {
            return await _waitlistRepository.RemoveAsync(id);
        }

        public async Task<WaitList?> UpdateAsync(WaitList entity)
        {
            return await _waitlistRepository.UpdateAsync(entity);
        }
    }
}
