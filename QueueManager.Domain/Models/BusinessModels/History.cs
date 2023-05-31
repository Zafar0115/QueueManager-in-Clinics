using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class History:BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset JoinedTime { get; set; }
        public DateTimeOffset CompletedTime { get; set; }
        public string? CustomerSatisfaction { get; set; } = null;
        public Guid ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
