using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.PatientDTO;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Infrastructure.Implementation;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ApiControllerBase<Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<PatientOutcomingDTO>>> Create([FromBody] PatientCreateDTO patientCreateDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientCreateDTO);
            var validationResult = _validator.Validate(patient);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<PatientOutcomingDTO>(false, validationResult.Errors));
            Patient? added = await _patientRepository.AddAsync(patient);
            if (added is null)
                return BadRequest(new ResponseCore<PatientOutcomingDTO>(false, "something wrong with database"));
            PatientOutcomingDTO? mappedResult = _mapper.Map<PatientOutcomingDTO>(added);
            return Ok(new ResponseCore<PatientOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<PatientOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Patient? patient = await _patientRepository.GetById(id);
            if (patient is null) return NotFound(new ResponseCore<PatientOutcomingDTO>(false, "patient not found"));
            var mappedResult = _mapper.Map<PatientOutcomingDTO>(patient);
            return Ok(new ResponseCore<PatientOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<PatientOutcomingDTO>>> GetAll()
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<PatientOutcomingDTO>>(patients);
            return Ok(new PaginatedList<PatientOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<PatientOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            Patient? deleted = await _patientRepository.RemoveAsync(id);
            if (deleted is null)
                return BadRequest(new ResponseCore<PatientOutcomingDTO>(false, $"Patient with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<PatientOutcomingDTO>(deleted);
            return Ok(new ResponseCore<PatientOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<PatientOutcomingDTO>>> Update([FromBody] PatientOutcomingDTO patientOutcomingDTO)
        {
            Patient? patient = _mapper.Map<Patient>(patientOutcomingDTO);
            var validationResult = _validator.Validate(patient);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<PatientOutcomingDTO>(false, validationResult.Errors));

            var updated = await _patientRepository.UpdateAsync(patient);
            if (updated is null)
                return BadRequest(new ResponseCore<PatientOutcomingDTO>(false, $"Object ID: {patient.PatientId} not found to update"));
            var mappedResult = _mapper.Map<PatientOutcomingDTO>(updated);
            return Ok(new ResponseCore<PatientOutcomingDTO>(mappedResult));
        }
    }
}
