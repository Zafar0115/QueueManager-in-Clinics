using FluentValidation;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Application.FluentValidation
{
    public class ClinicValidator:AbstractValidator<Clinic>
    {
        public ClinicValidator()
        {
            RuleFor(c=>c.ClinicName).NotEmpty().Length(2,50);
            RuleFor(c => c.Location).Length(5,10);
        }
    }
}
