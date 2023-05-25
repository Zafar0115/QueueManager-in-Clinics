using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.Interfaces.common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<IQueryable<T>> Get(Expression<Func<T, bool>>? expression = null);
        Task<IQueryable<T>> GetAll();
        Task<T?> AddAsync(T entity);
        Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities);
        Task<T?> UpdateAsync(T entity);
        Task<T?> RemoveAsync(Guid id);
    }
}
