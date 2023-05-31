using FluentValidation;
using QueueManager.Application.Extensions;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.UserName).Length(2,50).NotEmpty();
            RuleFor(u => u.EmailAddress).EmailAddress();
            RuleFor(u=>u.FullName).Length(4, 50).NotEmpty().Must(o => o.OnlyLetters());
            RuleFor(u => u.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$").WithMessage("invalid password");
            RuleFor(u => u.PhoneNumber).Matches(@"^998\d{9}$").WithMessage("invalid phone number");
        }

       
    }
}
