using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Application.DTOs.Common.HistoryDTO
{
    public class HistoryOutcomingDTO
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset JoinedTime { get; set; }
        public DateTimeOffset CompletedTime { get; set; }
        public string? CustomerSatisfaction { get; set; }
        public Guid ClinicId { get; set; }
    }
}
