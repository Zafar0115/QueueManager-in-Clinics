using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.WaitListDTO
{
    public class WaitListCreateDTO
    {
        public required Guid DoctorId { get; set; }
        public required Guid PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset? JoinedTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; } = null;

    }
}
