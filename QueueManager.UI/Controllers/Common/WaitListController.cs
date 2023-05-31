using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.WaitListDTO;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class WaitListController : ApiControllerBase<WaitList>
    {
        private readonly IWaitlistRepository _waitlistRepository;

        public WaitListController(IWaitlistRepository waitlistRepository)
        {
            _waitlistRepository = waitlistRepository;
        }
        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<WaitListOutcomingDTO>>> Create([FromBody] WaitListCreateDTO waitlistDTO)
        {
            WaitList waitlist = _mapper.Map<WaitList>(waitlistDTO);
            WaitList? added = await _waitlistRepository.AddAsync(waitlist);
            if (added is null)
                return BadRequest(new ResponseCore<WaitListOutcomingDTO>(false, "something wrong with database"));
            WaitListOutcomingDTO? mappedResult = _mapper.Map<WaitListOutcomingDTO>(added);
            return Ok(new ResponseCore<WaitListOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<WaitListOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            WaitList? waitList = await _waitlistRepository.GetById(id);
            if (waitList is null) return NotFound(new ResponseCore<WaitListOutcomingDTO>(false, "waitList not found"));
            var mappedResult = _mapper.Map<WaitListOutcomingDTO>(waitList);
            return Ok(new ResponseCore<WaitListOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<WaitListOutcomingDTO>>> GetAll()
        {
            IEnumerable<WaitList> waitLists = await _waitlistRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<WaitListOutcomingDTO>>(waitLists);
            return Ok(new PaginatedList<WaitListOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<WaitListOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            WaitList? deleted = await _waitlistRepository.RemoveAsync(id);
            if (deleted is null)
                return BadRequest(new ResponseCore<WaitListOutcomingDTO>(false, $"Clinic with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<WaitListOutcomingDTO>(deleted);
            return Ok(new ResponseCore<WaitListOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<WaitListOutcomingDTO>>> Update([FromBody] WaitListOutcomingDTO waitListOutcomingDTO)
        {
            WaitList? waitList = _mapper.Map<WaitList>(waitListOutcomingDTO);

            var updated = await _waitlistRepository.UpdateAsync(waitList);
            if (updated is null)
                return BadRequest(new ResponseCore<WaitListOutcomingDTO>(false, $"Object ID: {waitList.Id} not found to update"));
            var mappedResult = _mapper.Map<WaitListOutcomingDTO>(updated);
            return Ok(new ResponseCore<WaitListOutcomingDTO>(mappedResult));
        }
    }
}
