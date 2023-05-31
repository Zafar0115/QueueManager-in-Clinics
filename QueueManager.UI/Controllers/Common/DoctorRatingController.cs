using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.DoctorRatingDTO;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Infrastructure.Implementation;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorRatingController : ApiControllerBase<DoctorRating>
    {
        private readonly IDoctorRatingRepository _ratingRepository;

        public DoctorRatingController(IDoctorRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<DoctorRatingOutcomingDTO>>> Create([FromBody] DoctorRatingOutcomingDTO rating)
        {
            DoctorRating doctorRating = _mapper.Map<DoctorRating>(rating);
            var validationResult = _validator.Validate(doctorRating);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<DoctorRatingOutcomingDTO>(false, validationResult.Errors));
            DoctorRating? added = await _ratingRepository.AddAsync(doctorRating);
            if (added is null)
                return BadRequest(new ResponseCore<DoctorRatingOutcomingDTO>(false, "something wrong with database"));
            DoctorRatingOutcomingDTO? mappedResult = _mapper.Map<DoctorRatingOutcomingDTO>(added);
            return Ok(new ResponseCore<DoctorRatingOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<DoctorRatingOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            DoctorRating? rating = await _ratingRepository.GetById(id);
            if (rating is null) return NotFound(new ResponseCore<DoctorRatingOutcomingDTO>(false, "rating not found"));
            var mappedResult = _mapper.Map<DoctorRatingOutcomingDTO>(rating);
            return Ok(new ResponseCore<DoctorRatingOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<DoctorRatingOutcomingDTO>>> GetAll()
        {
            IEnumerable<DoctorRating> ratings = await _ratingRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<DoctorRatingOutcomingDTO>>(ratings);
            return Ok(new PaginatedList<DoctorRatingOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<DoctorRatingOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            DoctorRating? deleted = await _ratingRepository.RemoveAsync(id);
            if (deleted is null)
                return BadRequest(new ResponseCore<DoctorRatingOutcomingDTO>(false, $"Rating with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<DoctorRatingOutcomingDTO>(deleted);
            return Ok(new ResponseCore<DoctorRatingOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<DoctorRatingOutcomingDTO>>> Update([FromBody] DoctorRatingOutcomingDTO ratingOutcomingDTO)
        {
            DoctorRating? rating = _mapper.Map<DoctorRating>(ratingOutcomingDTO);
            var validationResult = _validator.Validate(rating);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<DoctorRatingOutcomingDTO>(false, validationResult.Errors));

            var updated = await _ratingRepository.UpdateAsync(rating);
            if (updated is null)
                return BadRequest(new ResponseCore<DoctorRatingOutcomingDTO>(false, $"Object ID: {rating.Id} not found to update"));
            var mappedResult = _mapper.Map<DoctorRatingOutcomingDTO>(updated);
            return Ok(new ResponseCore<DoctorRatingOutcomingDTO>(mappedResult));
        }
    }
}
