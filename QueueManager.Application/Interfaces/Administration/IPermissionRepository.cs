using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.Interfaces.Administration
{
    public interface IPermissionRepository:IGenericRepository<Permission>
    {
    }
}
