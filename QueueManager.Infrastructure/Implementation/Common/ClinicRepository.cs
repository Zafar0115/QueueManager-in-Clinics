using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
