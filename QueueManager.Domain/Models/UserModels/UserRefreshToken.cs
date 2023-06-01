using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Models.UserModels
{
    public class UserRefreshToken : BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset ExpiryDate { get; set; }
    }
}
