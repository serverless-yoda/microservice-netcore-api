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
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Minimum length of Username is 3 characters");
            //Complex entities
            RuleForEach(x => x.BasketOrders).ChildRules(orders => {
                orders.RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("Product Id should be greater than zero");
                orders.RuleFor(X => X.Price).NotNull().GreaterThan(0).WithMessage("Price should be greater than zero");
                orders.RuleFor(X => X.ProductName).NotNull().NotNull().NotEmpty().WithMessage("Product Name is empty");
                orders.RuleFor(X => X.Quantity).NotNull().GreaterThan(0).WithMessage("Quantity should be greater than zero");
            });
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
