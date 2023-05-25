using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using QueueManager.Domain.Abstract;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class WaitList:BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset? JoinedTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; } = null;
    }
}
