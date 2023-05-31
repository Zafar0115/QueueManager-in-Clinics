using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.DoctorRatingDTO
{
    public class DoctorRatingCreateDTO
    {
        public  string? RatingDescription { get; set; }
        public int StarValue { get; set; }
    }
}
