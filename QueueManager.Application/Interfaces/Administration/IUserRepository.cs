using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.Interfaces.Administration
{
    public interface IUserRepository:IGenericRepository<User>
    {
    }
}
