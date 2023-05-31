using FluentValidation;
using QueueManager.Application.Extensions;
using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.FluentValidation
{
    public class DoctorValidator:AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty().Length(3, 30).Must(o=>o.OnlyLetters());
            RuleFor(d => d.LastName).NotEmpty().Length(3, 30).Must(o => o.OnlyLetters());
            RuleFor(d => d.Experience).GreaterThan(0);
            RuleFor(d=>d.Email).EmailAddress();
            RuleFor(d => d.PhoneNumber).Must(o=>o.IsValidPhoneNumber());
        }
    }
}
