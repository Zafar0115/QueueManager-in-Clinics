using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
      
    }
}
