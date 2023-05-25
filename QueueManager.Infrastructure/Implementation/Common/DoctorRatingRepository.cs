using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Infrastructure.Implementation.common
{
    public class DoctorRatingRepository : GenericRepository<DoctorRating>, IDoctorRatingRepository
    {
        public DoctorRatingRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
