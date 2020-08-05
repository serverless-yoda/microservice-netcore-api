using CodeCheater.Application.Service;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCheater.Application.RequestValidation
{
    public class CategoryInsertValidator : AbstractValidator<CategoryInsertRequestViewModel>
    {
        private readonly IServiceProvider provider;
        public CategoryInsertValidator(IServiceProvider _provider)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).WithMessage("Name should not be empty and should be more than 3 characters").MustAsync(CheckCategory);
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description should not be empty");
            this.provider = _provider;
        }

        private async Task<bool> CheckCategory(string name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(name)) return true;

            var service = provider.GetRequiredService<ICategoryService>();
            return await service.IsCategoryNameExist(name);
        }
    }
}
