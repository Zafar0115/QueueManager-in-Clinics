using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.Services.role_services;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.UI.Controllers.userrole
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("get")]
        public async Task<IResult> GetById([FromQuery] Guid id)
        {
            return Results.Ok(await userService.GetById(id));
        }

        [HttpPost("add")]
        public async Task<IResult> AddAsync([FromBody] User user)
        {


            return Results.Ok(await userService.AddAsync(user));
        }

        [HttpPut("Update")]
        public async Task<IResult> Update([FromBody] User user)
        {
            User? res = await userService.UpdateAsync(user);
            return Results.Ok(res);
        }
        [HttpDelete("delete")]
        public async Task<IResult> Remove([FromBody] Guid id)
        {
            return Results.Ok(await userService.RemoveAsync(id));
        }

        [HttpGet("getAll")]
        public async Task<IResult> GetAll()
        {
            return Results.Ok(await userService.GetAll());
        }
    }
}
