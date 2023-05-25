using QueueManager.Domain.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Application.DTOs.AdminDTO.UserRefreshTokenDTO
{
    public class UserRefreshTokenBaseDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
    }
}
