using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.Common;
using System.Linq.Expressions;

namespace QueueManager.Infrastructure.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly IApplicationDbContext _dbContext;
        public GenericRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T?> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            int result = await _dbContext.SaveChangesAsync();
            if (result > 0)
                return entity;
            return null;
        }

        public virtual async Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            int result = await _dbContext.SaveChangesAsync();
            if (result > 0)
                return entities;
            return null;

        }

        public virtual async Task<T?> RemoveAsync(Guid id)
        {
            T? entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is not null)
                _dbContext.Set<T>().Remove(entity);
            int result = await _dbContext.SaveChangesAsync();
            if (result > 0)
                return entity;
            return null;

        }

        public virtual Task<IQueryable<T>> Get(Expression<Func<T, bool>>? expression = default)
        {
            if (expression is null) return GetAll();
            IQueryable<T> result = _dbContext.Set<T>().Where(expression).AsQueryable();
            return Task.FromResult(result);
        }

        public virtual Task<IQueryable<T>> GetAll()
        {
            IQueryable<T> result = _dbContext.Set<T>().AsQueryable();
            return Task.FromResult(result);
        }

        public virtual Task<T?> GetById(Guid id)
        {
            T? entity = _dbContext.Set<T>().Find(id);
            return Task.FromResult(entity);
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            int result = 0;
            _dbContext.Set<T>().Update(entity);
            result = await _dbContext.SaveChangesAsync();
            return result > 0 ? entity : null;
        }
    }
}
