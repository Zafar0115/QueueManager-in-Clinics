using QueueManager.Domain.Abstract;
using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Domain.Models.UserModels
{
    public class User : BaseAuditableEntity
    {
        public Guid Id { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string FullName { get; set; }
        public Guid ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public virtual IList<Role>? Roles { get; set; }
        public virtual IList<UserRefreshToken>? UserRefreshTokens { get; set; }
    }
}
