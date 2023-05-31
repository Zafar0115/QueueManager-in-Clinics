using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.DoctorDTO;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Infrastructure.Implementation;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ApiControllerBase<Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
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

    }
}
