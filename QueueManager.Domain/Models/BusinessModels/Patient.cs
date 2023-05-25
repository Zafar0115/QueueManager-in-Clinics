using QueueManager.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueManager.Domain.Models.BusinessModels
{
    public class Patient : Person
    {
        public Guid PatientId { get; set; }
        public WaitList? WaitList { get; set; }
    }
}
