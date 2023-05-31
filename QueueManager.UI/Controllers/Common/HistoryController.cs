using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.Common.HistoryDTO;
using QueueManager.Application.DTOs.Common.WaitListDTO;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ApiControllerBase<History>
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<ActionResult<ResponseCore<HistoryOutcomingDTO>>> Create([FromBody] HistoryCreateDTO historyCreateDTO)
        {
            History history = _mapper.Map<History>(historyCreateDTO);
            History? added = await _historyRepository.AddAsync(history);
            if (added is null)
                return BadRequest(new ResponseCore<HistoryOutcomingDTO>(false, "something wrong with database"));
            HistoryOutcomingDTO? mappedResult = _mapper.Map<HistoryOutcomingDTO>(added);
            return Ok(new ResponseCore<HistoryOutcomingDTO>(mappedResult));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<HistoryOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            History? history = await _historyRepository.GetById(id);
            if (history is null) return NotFound(new ResponseCore<HistoryOutcomingDTO>(false, "history not found"));
            var mappedResult = _mapper.Map<HistoryOutcomingDTO>(history);
            return Ok(new ResponseCore<HistoryOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<HistoryOutcomingDTO>>> GetAll()
        {
            IEnumerable<History> histories = await _historyRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<HistoryOutcomingDTO>>(histories);
            return Ok(new PaginatedList<HistoryOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<HistoryOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            History? deleted = await _historyRepository.RemoveAsync(id);
            if (deleted is null)
                return BadRequest(new ResponseCore<HistoryOutcomingDTO>(false, $"History with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<HistoryOutcomingDTO>(deleted);
            return Ok(new ResponseCore<HistoryOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<HistoryOutcomingDTO>>> Update([FromBody] HistoryOutcomingDTO historyOutcomingDTO)
        {
            History? history = _mapper.Map<History>(historyOutcomingDTO);

            var updated = await _historyRepository.UpdateAsync(history);
            if (updated is null)
                return BadRequest(new ResponseCore<HistoryOutcomingDTO>(false, $"Object ID: {history} not found to update"));
            var mappedResult = _mapper.Map<HistoryOutcomingDTO>(updated);
            return Ok(new ResponseCore<HistoryOutcomingDTO>(mappedResult));
        }
    }
}
