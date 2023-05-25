using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.DoctorDTO
{
    public class DoctorBaseDTO
    {
        public Guid DoctorId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? CategoryId { get; set; }
        public float Experience { get; set; }
        public DoctorRating? Rating { get; set; }

    }
}
