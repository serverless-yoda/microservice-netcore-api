using FluentValidation;
using System;

namespace CodeCheater.Application.RequestValidation
{
    public class BasketInsertValidator : AbstractValidator<BasketInsertRequestViewModel>
    {
        private readonly IServiceProvider provider;

        public BasketInsertValidator(IServiceProvider provider)
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("UserName is Empty");
            RuleFor(x => x.UserName).NotNull().MinimumLength(3).WithMessage("Minimum length of Username is 3 characters");
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
