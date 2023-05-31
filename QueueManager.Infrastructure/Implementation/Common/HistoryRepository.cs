using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation.common
{
    public class HistoryRepository : GenericRepository<History>, IHistoryRepository
    {
        public HistoryRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
