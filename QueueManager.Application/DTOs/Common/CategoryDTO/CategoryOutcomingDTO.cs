using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.CategoryDTO
{
    public class CategoryOutcomingDTO
    {
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
