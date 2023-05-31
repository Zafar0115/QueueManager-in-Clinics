using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.AdminDTO.PermissionDTO;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.UserModels;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.userrole
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ApiControllerBase<Permission>
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ResponseCore<PermissionOutcomingDTO>>> Add([FromBody] PermissionCreateDTO permissionCreateDTO)
        {
            Permission? permission = _mapper.Map<Permission>(permissionCreateDTO);
            var result = _validator.Validate(permission);
            if (!result.IsValid)
                return BadRequest(new ResponseCore<Permission>(false, result.Errors));

            var permissionCreated = await _permissionRepository.AddAsync(permission);
            if (permissionCreated is null)
                return BadRequest(new ResponseCore<Permission>(false, "Permission could not be saved"));

            var mappedResult = _mapper.Map<PermissionOutcomingDTO>(permissionCreated);
            return Ok(new ResponseCore<PermissionOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ResponseCore<PermissionOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Permission? permission = await _permissionRepository.GetById(id);
            if (permission is null)
                return BadRequest(new ResponseCore<PermissionOutcomingDTO>(false, "Permission not found"));
            var mappedResult = _mapper.Map<PermissionOutcomingDTO>(permission);
            return Ok(new ResponseCore<PermissionOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<PermissionOutcomingDTO>>> GetAll()
        {
            IEnumerable<Permission> permissions = await _permissionRepository.GetAll();
            IEnumerable<PermissionOutcomingDTO> mappedResult = _mapper.Map<IEnumerable<PermissionOutcomingDTO>>(permissions);
            return Ok(new PaginatedList<PermissionOutcomingDTO>(mappedResult.AsQueryable(), 5, 5, 5));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<PermissionOutcomingDTO>>> Update([FromBody] PermissionOutcomingDTO permissionOutcomingDTO)
        {
            Permission permission = _mapper.Map<Permission>(permissionOutcomingDTO);
            var validationResult = _validator.Validate(permission);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<PermissionOutcomingDTO>(false, validationResult.Errors));

            var updated = await _permissionRepository.UpdateAsync(permission);
            if (updated is null)
                return BadRequest(new ResponseCore<PermissionOutcomingDTO>(false, $"Object ID: {permission.Id} not found to update"));

            var mappedResult = _mapper.Map<PermissionOutcomingDTO>(updated);
            return Ok(new ResponseCore<PermissionOutcomingDTO>(mappedResult));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<PermissionOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            Permission? deletedPermission = await _permissionRepository.RemoveAsync(id);
            if (deletedPermission is null)
                return BadRequest(new ResponseCore<PermissionOutcomingDTO>(false, $"Permission with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<PermissionOutcomingDTO>(deletedPermission);
            return Ok(new ResponseCore<PermissionOutcomingDTO>(mappedResult));
        }



    }
}
