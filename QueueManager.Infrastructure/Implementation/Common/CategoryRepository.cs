using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
