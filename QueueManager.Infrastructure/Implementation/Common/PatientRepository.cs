using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.Common;
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
