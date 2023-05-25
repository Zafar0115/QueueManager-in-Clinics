using QueueManager.Application.Abstraction;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.common;
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
