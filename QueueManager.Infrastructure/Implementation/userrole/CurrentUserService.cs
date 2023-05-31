using Microsoft.AspNetCore.Http;
using QueueManager.Application.Interfaces.Administration;
using System.Security.Claims;

namespace QueueManager.Infrastructure.Implementation.userrole
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string? UserId => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
