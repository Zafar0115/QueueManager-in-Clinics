using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.AdminDTO.UserDTO;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using QueueManager.UI.Controllers.ApiController;

namespace QueueManager.UI.Controllers.Administrator
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IClinicRepository _clinicRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IClinicRepository clinicRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _clinicRepository = clinicRepository;
        }
        [HttpPost("add")]
        public async Task<ActionResult<ResponseCore<UserOutcomingDTO>>> Add([FromBody] UserCreateDTO userCreateDTO)
        {
            User? user = _mapper.Map<User>(userCreateDTO);
            //var validationResult = _validator.Validate(user);
            //if (!validationResult.IsValid)
            //    return BadRequest(new ResponseCore<UserOutcomingDTO>(false, validationResult.Errors));

            Clinic? clinic = await _clinicRepository.GetById(userCreateDTO.ClinicId);
            if (clinic is null)
                return BadRequest(new ResponseCore<UserOutcomingDTO>(false, "clinic not found"));

            user.Roles = new List<Role>();
            if (userCreateDTO.RoleIds is not null)
                foreach (Guid id in userCreateDTO.RoleIds)
                {
                    Role? role = await _roleRepository.GetById(id);
                    if (role is null)
                        return BadRequest(new ResponseCore<UserOutcomingDTO>(false, $"RoleID: {id} not found"));
                    user.Roles.Add(role);
                }
            User? userAdded = await _userRepository.AddAsync(user);
            var mappedResult = _mapper.Map<UserOutcomingDTO>(userAdded);
            return Ok(new ResponseCore<UserOutcomingDTO>(mappedResult));
        }

        [HttpGet("getById")]
        public async Task<ActionResult<ResponseCore<UserOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is null)
                return BadRequest(new ResponseCore<UserOutcomingDTO>(false, $"User not found for ID:{id}"));
            var mappedUser = _mapper.Map<UserOutcomingDTO>(user);
            return Ok(new ResponseCore<UserOutcomingDTO>(mappedUser));
        }

        [HttpGet("getall")]
        public async Task<ActionResult<PaginatedList<UserOutcomingDTO>>> GetAll()
        {
            IEnumerable<User>? users = await _userRepository.GetAll();
            var mappedUsers = _mapper.Map<IEnumerable<UserOutcomingDTO>>(users);
            return Ok(new PaginatedList<UserOutcomingDTO>(mappedUsers.AsQueryable(), 5, 5, 5));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ResponseCore<User>>> Delete([FromQuery]Guid id)
        {
            User? deletedUser = await _userRepository.RemoveAsync(id);
            if (deletedUser is null) return BadRequest(new ResponseCore<UserOutcomingDTO>(false, "User not found"));
            var mappedUser = _mapper.Map<UserOutcomingDTO>(deletedUser);
            return Ok(new ResponseCore<UserOutcomingDTO>(mappedUser));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ResponseCore<UserOutcomingDTO>>> Update([FromBody] UserOutcomingDTO userOutcomingDTO)
        {
            User? user=_mapper.Map<User>(userOutcomingDTO);
            //var validationResult=_validator.Validate(user);
            //if (!validationResult.IsValid)
            //    return BadRequest(new ResponseCore<UserOutcomingDTO>(false, validationResult.Errors));
            Clinic? clinic = await _clinicRepository.GetById(userOutcomingDTO.ClinicId);
            if (clinic is null)
                return BadRequest(new ResponseCore<UserOutcomingDTO>(false, "clinic not found"));

            user.Roles = new List<Role>();
            if (userOutcomingDTO.RoleIds is not null)
                foreach (Guid id in userOutcomingDTO.RoleIds)
                {
                    Role? role = await _roleRepository.GetById(id);
                    if (role is null)
                        return BadRequest(new ResponseCore<UserOutcomingDTO>(false, $"RoleID: {id} not found"));
                    user.Roles.Add(role);
                }
            
            user.Roles=user.Roles.DistinctBy(x => x.Id).ToList();

            User? userUpdated = await _userRepository.UpdateAsync(user);
            
            var mappedResult = _mapper.Map<UserOutcomingDTO>(userUpdated);
            return Ok(new ResponseCore<UserOutcomingDTO>(mappedResult));
        }
     }
}
