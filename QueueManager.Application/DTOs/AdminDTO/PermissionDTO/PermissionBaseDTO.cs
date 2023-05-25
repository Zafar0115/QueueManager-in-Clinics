using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QueueManager.Domain.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueueManager.Application.DTOs.AdminDTO.PermissionDTO
{
    public class PermissionBaseDTO
    {
        public Guid Id { get; set; }
        public required string PermissionName { get; set; }
        public string? Description { get; set; }
    }
}
