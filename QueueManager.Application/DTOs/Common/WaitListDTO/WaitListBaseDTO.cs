using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.WaitListDTO
{
    public class WaitListBaseDTO
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
