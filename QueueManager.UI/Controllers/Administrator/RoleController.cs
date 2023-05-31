using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.AdminDTO.RoleDTO;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.UserModels;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.userrole
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ApiControllerBase<Role>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public RoleController(IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseCore<RoleOutcomingDTO>>> Add([FromBody] RoleCreateDTO roleCreateDTO)
        {
            var mappedRole = _mapper.Map<Role>(roleCreateDTO);
            var validationResult = _validator.Validate(mappedRole);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<RoleOutcomingDTO>(false, validationResult.Errors));
            mappedRole.Permissions = new List<Permission>();
            if(roleCreateDTO.PermissionIds is not null)
                foreach (Guid id in roleCreateDTO.PermissionIds)
                {
                    Permission? obj = await _permissionRepository.GetById(id);

                    if (obj is null)
                    return BadRequest(new ResponseCore<RoleOutcomingDTO>(false,$"Permission ID:{id} not found"));
                        mappedRole.Permissions.Add(obj);
                    
                }

            Role? addedRole = await _roleRepository.AddAsync(mappedRole);
            if (addedRole is null)
                return BadRequest(new ResponseCore<RoleOutcomingDTO>(false, "Role could not be saved"));
            var mappedResult = _mapper.Map<RoleOutcomingDTO>(addedRole);
            return Ok(new ResponseCore<RoleOutcomingDTO>(mappedResult));
        }

        [HttpGet("get")]
        public async Task<ActionResult<ResponseCore<RoleOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Role? role = await _roleRepository.GetById(id);
            if (role is null)
                return BadRequest(new ResponseCore<Role>(false, $"Role for ID: \"{id}\" not found"));
            var mappedRole=_mapper.Map<RoleOutcomingDTO>(role);
            return Ok(new ResponseCore<RoleOutcomingDTO>(mappedRole));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<RoleOutcomingDTO>>> GetAll()
        {
            IEnumerable<Role> roles = await _roleRepository.GetAll();
            IEnumerable<RoleOutcomingDTO> mappedRoles = _mapper.Map<IEnumerable<RoleOutcomingDTO>>(roles);
            return Ok(new PaginatedList<RoleOutcomingDTO>(mappedRoles.AsQueryable(), 10, 10, 10));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ResponseCore<RoleOutcomingDTO>>> Delete([FromQuery] Guid id)
        {
            Role? deletedRole = await _roleRepository.RemoveAsync(id);
            if(deletedRole is null)
                return NotFound(new ResponseCore<RoleOutcomingDTO>(false,$"Role ID: {id} not found to delete"));
            RoleOutcomingDTO? mappedResult = _mapper.Map<RoleOutcomingDTO>(deletedRole);
            return Ok(new ResponseCore<RoleOutcomingDTO>(mappedResult));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ResponseCore<RoleOutcomingDTO>>> Update([FromBody] RoleUpdateDTO roleUpdateDTO)
        {
            Role role = _mapper.Map<Role>(roleUpdateDTO);
            ValidationResult validationResult = _validator.Validate(role);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<RoleOutcomingDTO>(false, validationResult.Errors));
          
           role.Permissions=new List<Permission>();
            if(roleUpdateDTO.PermissionIds is not null)
            foreach (Guid id in roleUpdateDTO.PermissionIds)
            {
                   Permission? permission= await _permissionRepository.GetById(id);
                    if (permission is null)
                        return BadRequest(new ResponseCore<RoleOutcomingDTO>(false, $"Permission ID: {id} not found"));
                    role.Permissions.Add(permission);
            }
            role.Permissions = role.Permissions.DistinctBy(x => x.Id).ToList();
            Role? updatedRole=await _roleRepository.UpdateAsync(role);
            if (updatedRole is null)
                return BadRequest(new ResponseCore<RoleOutcomingDTO>(false, $"Entity with ID: {role.Id} could not be found to update"));
            var mappedResult=_mapper.Map<RoleOutcomingDTO>(updatedRole);
            return Ok(new ResponseCore<RoleOutcomingDTO>(mappedResult));
        }

    }
}
