using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services
{
    public class DoctorService:IDoctorRepository
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor?> AddAsync(Doctor entity)
        {
            return await _doctorRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Doctor>?> AddRangeAsync(IEnumerable<Doctor> entities)
        {
            return await _doctorRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<Doctor>> Get(Expression<Func<Doctor, bool>>? expression = null)
        {
            return await _doctorRepository.Get(expression);
        }

        public async Task<IQueryable<Doctor>> GetAll()
        {
            return await _doctorRepository.GetAll();
        }

        public async Task<Doctor?> GetById(Guid id)
        {
            return await _doctorRepository.GetById(id);
        }

        public async Task<Doctor?> RemoveAsync(Guid id)
        {
            return await _doctorRepository.RemoveAsync(id);
        }

        public async Task<Doctor?> UpdateAsync(Doctor entity)
        {
            return await _doctorRepository.UpdateAsync(entity);
        }
    }
}
