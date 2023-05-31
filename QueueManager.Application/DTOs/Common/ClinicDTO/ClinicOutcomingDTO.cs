using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.ClinicDTO
{
    public class ClinicOutcomingDTO
    {
        public Guid ClinicId { get; set; }
        public required string ClinicName { get; set; }
        public required string Location { get; set; }
    }
}
