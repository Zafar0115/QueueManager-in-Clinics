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
        public ICollection<DoctorRating>? DoctorRatings { get; set; }
        public ICollection<DoctorClinic>? DoctorClinics { get; set; }

    }
}
