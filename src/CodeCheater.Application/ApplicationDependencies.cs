using CodeCheater.Application.RequestValidation;
using CodeCheater.Application.Service;
using CodeCheater.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCheater.Application
{
    public static class ApplicationDependencies
    {
        public static void InjectRedis(IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IValidator<BasketInsertRequestViewModel>, BasketInsertValidator>();
        }

        public static void InjectEFCore(IServiceCollection services, IConfiguration config)
        {
           
            services.AddScoped(typeof(IBaseEFRepository<>), typeof(BaseEFRepository<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            
        }
    }
}
