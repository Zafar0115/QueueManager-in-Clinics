using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.DoctorDTO
{
    public class DoctorCreateDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid CategoryId { get; set; }
        public float Experience { get; set; }
        public Guid RatingId { get; set; }
        public Guid[]? ClinicIds { get; set;}
    }
}
