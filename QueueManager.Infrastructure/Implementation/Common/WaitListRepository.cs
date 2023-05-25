using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation.common
{
    public class WaitListRepository : GenericRepository<WaitList>, IWaitlistRepository
    {
        public WaitListRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
