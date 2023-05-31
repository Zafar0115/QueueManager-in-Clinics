using Microsoft.EntityFrameworkCore.Migrations;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.Common;
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
