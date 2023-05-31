using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.CategoryDTO;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Infrastructure.Implementation;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController:ApiControllerBase<Clinic>
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<ClinicOutcomingDTO>>> Create([FromBody] ClinicCreateDTO clinicCreateDTO)
        {
            Clinic clinic = _mapper.Map<Clinic>(clinicCreateDTO);
            var validationResult = _validator.Validate(clinic);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<ClinicOutcomingDTO>(false, validationResult.Errors));
            Clinic? addedClinic = await _clinicRepository.AddAsync(clinic);
            if (addedClinic is null)
                return BadRequest(new ResponseCore<ClinicOutcomingDTO>(false, "something wrong with database"));
            ClinicOutcomingDTO? mappedResult = _mapper.Map<ClinicOutcomingDTO>(addedClinic);
            return Ok(new ResponseCore<ClinicOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<ClinicOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Clinic? clinic = await _clinicRepository.GetById(id);
            if (clinic is null) return NotFound(new ResponseCore<ClinicOutcomingDTO>(false, "clinic not found"));
            var mappedResult = _mapper.Map<ClinicOutcomingDTO>(clinic);
            return Ok(new ResponseCore<ClinicOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<ClinicOutcomingDTO>>> GetAll()
        {
            IEnumerable<Clinic> clinics = await _clinicRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<ClinicOutcomingDTO>>(clinics);
            return Ok(new PaginatedList<ClinicOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<ClinicOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            Clinic? deletedClinic = await _clinicRepository.RemoveAsync(id);
            if (deletedClinic is null)
                return BadRequest(new ResponseCore<ClinicOutcomingDTO>(false, $"Clinic with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<ClinicOutcomingDTO>(deletedClinic);
            return Ok(new ResponseCore<ClinicOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<ClinicOutcomingDTO>>> Update([FromBody] ClinicOutcomingDTO clinicOutcomingDTO)
        {
            Clinic? clinic = _mapper.Map<Clinic>(clinicOutcomingDTO);
            var validationResult = _validator.Validate(clinic);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<ClinicOutcomingDTO>(false, validationResult.Errors));

            var updated = await _clinicRepository.UpdateAsync(clinic);
            if (updated is null)
                return BadRequest(new ResponseCore<ClinicOutcomingDTO>(false, $"Object ID: {clinic.ClinicId} not found to update"));
            var mappedResult = _mapper.Map<ClinicOutcomingDTO>(updated);
            return Ok(new ResponseCore<ClinicOutcomingDTO>(mappedResult));
        }
    }
}
