using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.BusinessModels;
using System.Linq.Expressions;

namespace QueueManager.Application.Services
{
    public class PatientService:IPatientRepository
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient?> AddAsync(Patient entity)
        {
            return await _patientRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Patient>?> AddRangeAsync(IEnumerable<Patient> entities)
        {
           return await _patientRepository.AddRangeAsync(entities);
        }

        public async Task<IQueryable<Patient>> Get(Expression<Func<Patient, bool>>? expression = null)
        {
            return await _patientRepository.Get(expression);
        }

        public async Task<IQueryable<Patient>> GetAll()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patient?> GetById(Guid id)
        {
            return await _patientRepository.GetById(id);
        }

        public async Task<Patient?> RemoveAsync(Guid id)
        {
            return await _patientRepository.RemoveAsync(id);
        }

        public async Task<Patient?> UpdateAsync(Patient entity)
        {
            return await _patientRepository.UpdateAsync(entity);
        }
    }
}
