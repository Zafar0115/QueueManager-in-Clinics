using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueueManager.Application.DTOs.AdminDTO.UserDTO
{
    public class UserBaseDTO
    {
        public Guid Id { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public Guid? ClinicId { get; set; }

    }
}
