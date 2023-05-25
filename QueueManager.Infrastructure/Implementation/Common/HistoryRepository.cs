using Microsoft.EntityFrameworkCore.Migrations;
using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation.common
{
    public class HistoryRepository : GenericRepository<History>, Application.Interfaces.common.IHistoryRepository
    {
        public HistoryRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
