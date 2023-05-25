using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.Services
{
    public class DoctorRatingService:IDoctorRatingRepository
    {
        private readonly IDoctorRatingRepository _doctorRatingRepository;

        public DoctorRatingService(IDoctorRatingRepository doctorRatingRepository)
        {
            _doctorRatingRepository = doctorRatingRepository;
        }

        public async Task<DoctorRating?> AddAsync(DoctorRating entity)
        {
            return await _doctorRatingRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<DoctorRating>?> AddRangeAsync(IEnumerable<DoctorRating> entities)
        {
            return await _doctorRatingRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<DoctorRating>> Get(Expression<Func<DoctorRating, bool>>? expression = null)
        {
            return await _doctorRatingRepository.Get(expression);
        }

        public async Task<IQueryable<DoctorRating>> GetAll()
        {
            return await _doctorRatingRepository.GetAll();
        }

        public async Task<DoctorRating?> GetById(Guid id)
        {
            return await _doctorRatingRepository.GetById(id);
        }

        public async Task<DoctorRating?> RemoveAsync(Guid id)
        {
            return await _doctorRatingRepository.RemoveAsync(id);
        }

        public async Task<DoctorRating?> UpdateAsync(DoctorRating entity)
        {
            return await _doctorRatingRepository.UpdateAsync(entity);
        }
    }
}
