using Microsoft.EntityFrameworkCore.Migrations;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;
using IHistoryRepository = QueueManager.Application.Interfaces.common.IHistoryRepository;

namespace QueueManager.Application.Services
{
    public class HistoryService:IHistoryRepository
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<History?> AddAsync(History entity)
        {
            return await _historyRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<History>?> AddRangeAsync(IEnumerable<History> entities)
        {
            return await _historyRepository.AddRangeAsync(entities);    
        }

        public async Task<IQueryable<History>> Get(Expression<Func<History, bool>>? expression = null)
        {
            return await _historyRepository.Get(expression);
        }

        public async Task<IQueryable<History>> GetAll()
        {
            return await _historyRepository.GetAll();
        }

        public async Task<History?> GetById(Guid id)
        {
            return await _historyRepository.GetById(id);
        }

        public async Task<History?> RemoveAsync(Guid id)
        {
            return await _historyRepository.RemoveAsync(id);
        }

        public async Task<History?> UpdateAsync(History entity)
        {
           return await _historyRepository.UpdateAsync(entity);
        }
    }
}
