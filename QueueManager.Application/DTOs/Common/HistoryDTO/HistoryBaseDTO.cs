using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.HistoryDTO
{
    public class HistoryBaseDTO
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset? JoinedTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; } = null;
        public string? CustomerSatisfaction { get; set; } = null;
        public Guid ClinicId { get; set; }
    }
}
