using FluentValidation;
using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.FluentValidation
{
    public class DoctorRatingValidator:AbstractValidator<DoctorRating>
    {
        public DoctorRatingValidator()
        {
            RuleFor(dr => dr.StarValue).InclusiveBetween(1, 5);
            RuleFor(dr => dr.RatingDescription).NotEmpty().Length(3,50);
        }
    }
}
