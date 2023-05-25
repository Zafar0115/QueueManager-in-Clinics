using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class Category:BaseAuditableEntity
    {
        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }
    }
}