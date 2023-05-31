using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.DoctorDTO;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Infrastructure.Implementation;
using QueueManager.UI.Controllers.ApiController;
using System.Diagnostics;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ApiControllerBase<Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IClinicRepository _clinicRepository;

        public DoctorController(IDoctorRepository doctorRepository, IClinicRepository clinicRepository)
        {
            _doctorRepository = doctorRepository;
            _clinicRepository = clinicRepository;
        }
        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<DoctorOutcomingDTO>>> Create([FromBody] DoctorCreateDTO doctorCreateDTO)
        {
            Doctor doctor = _mapper.Map<Doctor>(doctorCreateDTO);
            var validationResult = _validator.Validate(doctor);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, validationResult.Errors));
            Doctor? addedDoctor = await _doctorRepository.AddAsync(doctor);
            if (addedDoctor is null)
                return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, "something wrong with database"));
            DoctorOutcomingDTO? mappedResult = _mapper.Map<DoctorOutcomingDTO>(addedDoctor);
            return Ok(new ResponseCore<DoctorOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<DoctorOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Doctor? doctor = await _doctorRepository.GetById(id);
            if (doctor is null) return NotFound(new ResponseCore<DoctorOutcomingDTO>(false, $"doctor ID: {id} not found"));
            var mappedResult = _mapper.Map<DoctorOutcomingDTO>(doctor);
            return Ok(new ResponseCore<DoctorOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<DoctorOutcomingDTO>>> GetAll()
        {
            IEnumerable<Doctor> doctors = await _doctorRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<DoctorOutcomingDTO>>(doctors);
            return Ok(new PaginatedList<DoctorOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<DoctorOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            Doctor? deleted = await _doctorRepository.RemoveAsync(id);
            if (deleted is null)
                return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, $"Doctor with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<DoctorOutcomingDTO>(deleted);
            return Ok(new ResponseCore<DoctorOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<DoctorOutcomingDTO>>> Update([FromBody] DoctorOutcomingDTO doctorOutcomingDTO)
        {
            Doctor? doctor = _mapper.Map<Doctor>(doctorOutcomingDTO);
            var validationResult = _validator.Validate(doctor);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, validationResult.Errors));
            doctor.Clinics=new List<Clinic>();
            foreach (Guid id in doctorOutcomingDTO.ClinicIds)
            {
                Clinic? clinic =await _clinicRepository.GetById(id);
                if (clinic is null) return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, $"Clinic: {id} not found"));
                doctor.Clinics.Add(clinic);
            }

            var updated = await _doctorRepository.UpdateAsync(doctor);
            if (updated is null)
                return BadRequest(new ResponseCore<DoctorOutcomingDTO>(false, $"something went wrong with databae"));
            var mappedResult = _mapper.Map<DoctorOutcomingDTO>(updated);
            return Ok(new ResponseCore<DoctorOutcomingDTO>(mappedResult));
        }
    }
}
