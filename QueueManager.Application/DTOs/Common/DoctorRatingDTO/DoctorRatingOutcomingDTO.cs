using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.DoctorRatingDTO
{
    public class DoctorRatingOutcomingDTO
    {
        public Guid Id { get; set; }
        public  string? RatingDescription { get; set; }
        public int StarValue { get; set; }
    }
}
