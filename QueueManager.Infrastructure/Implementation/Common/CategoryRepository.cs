using QueueManager.Application.Interfaces.Common;
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
