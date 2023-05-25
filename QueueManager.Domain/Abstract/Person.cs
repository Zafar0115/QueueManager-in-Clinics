using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Abstract
{
    public abstract class Person:BaseAuditableEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
