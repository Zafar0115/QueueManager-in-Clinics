using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QueueManager.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.AdminDTO.RoleDTO
{
    public class RoleBaseDTO
    {
        public Guid Id { get; set; }
        public required string RoleName { get; set; }
    }
}
