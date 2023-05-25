using FluentValidation;
using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services
{
    public class ClinicService:IClinicRepository
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<Clinic?> AddAsync(Clinic entity)
        {
           return await _clinicRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Clinic>?> AddRangeAsync(IEnumerable<Clinic> entities)
        {
            return await _clinicRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<Clinic>> Get(Expression<Func<Clinic, bool>>? expression = null)
        {
            return await _clinicRepository.Get(expression);
        }

        public async Task<IQueryable<Clinic>> GetAll()
        {
           return await _clinicRepository.GetAll();     
        }

        public async Task<Clinic?> GetById(Guid id)
        {
            return await _clinicRepository.GetById(id);
        }

        public async Task<Clinic?>   RemoveAsync(Guid id)
        {
            return await _clinicRepository.RemoveAsync(id);
        }

        public async Task<Clinic?> UpdateAsync(Clinic entity)
        {
            return await _clinicRepository.UpdateAsync(entity);
        }
    }
}
