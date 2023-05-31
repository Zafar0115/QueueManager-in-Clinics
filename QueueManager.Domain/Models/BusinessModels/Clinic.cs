using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class Clinic:BaseAuditableEntity
    {
        public Guid ClinicId { get; set; }
        public  string? ClinicName { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
