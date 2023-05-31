using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class DoctorRating:BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public required string RatingDescription { get; set; }
       
        /// <summary>
        /// to rate out of five stars *****
        /// </summary>
        
        public int StarValue { get; set; }

        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
