using FluentValidation;
using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.FluentValidation
{
    public class PatientValidator:AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty().Length(3, 30);
            RuleFor(d => d.LastName).NotEmpty().Length(3, 30);
            RuleFor(d => d.Email).EmailAddress();
            RuleFor(d => d.PhoneNumber).Matches(@"^\+?\d{1,3}[-.\s]?\(?\d{1,3}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$");
        }
    }
}
