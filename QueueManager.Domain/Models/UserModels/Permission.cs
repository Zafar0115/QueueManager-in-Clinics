using QueueManager.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Domain.Models.UserModels
{
    public class Permission:BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public required string PermissionName { get; set; }
        public string? Description { get; set; }
        public IList<RolePermission>? RolePermissions { get; set; }

    }
}
