using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services
{
    public class CategoryService :ICategoryRepository
    {
        private  readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> AddAsync(Category entity)
        {
            return await _categoryRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Category>?> AddRangeAsync(IEnumerable<Category> entities)
        {
            return await _categoryRepository.AddRangeAsync(entities);
        }

        public async Task<Category?> RemoveAsync(Guid id)
        {
            return await _categoryRepository.RemoveAsync(id);
        }

        public async Task<IQueryable<Category>> Get(Expression<Func<Category, bool>>? expression = null)
        {
            return await _categoryRepository.Get(expression);
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category?> UpdateAsync(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }
    }
}
