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
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
