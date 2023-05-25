using QueueManager.Application.Abstraction;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation.common
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
      
    }
}
