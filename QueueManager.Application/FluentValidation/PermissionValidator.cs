using FluentValidation;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.FluentValidation
{
    public class PermissionValidator:AbstractValidator<Permission>
    {
        public PermissionValidator()
        {
            RuleFor(p=>p.PermissionName).NotEmpty().Length(2,50);
        }
    }
}
