using FluentValidation;
using QueueManager.Application.Extensions;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.FluentValidation
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.RoleName).NotEmpty().Length(2,50);
        }
    }
}
