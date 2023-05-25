using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.ClinicDTO
{
    public class ClinicCreateDTO
    {
        public required string ClinicName { get; set; }
        public required string Location { get; set; }
    }
}
