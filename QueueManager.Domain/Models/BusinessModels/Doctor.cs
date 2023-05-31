using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class Doctor : Person
    {
        public Guid DoctorId { get; set; }
        public Category? Category { get; set; }
        public float Experience { get; set; }
        public DoctorRating? RatingId { get; set; }
        public virtual ICollection<Clinic>? Clinics { get; set; }

    }
}
