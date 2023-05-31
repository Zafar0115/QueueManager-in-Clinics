using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.AdminDTO.PermissionDTO
{
    public class PermissionOutcomingDTO
    {
        public Guid Id { get; set; }
        public required string PermissionName { get; set; }
        public string? Description { get; set; }
    }
}
