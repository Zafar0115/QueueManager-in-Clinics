using QueueManager.Domain.Abstract;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class DoctorClinic:BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Guid ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
