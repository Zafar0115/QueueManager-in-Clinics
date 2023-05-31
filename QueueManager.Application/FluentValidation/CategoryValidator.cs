using FluentValidation;
using QueueManager.Application.Extensions;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Application.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName).NotEmpty()
                .Length(2,50).WithMessage("Invalid length")
                .Must(x=>x.OnlyLetters());
        }
    }
}
