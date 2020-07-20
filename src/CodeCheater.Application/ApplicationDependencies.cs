using CodeCheater.Application.Service;
using CodeCheater.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCheater.Application
{
    public static class ApplicationDependencies
    {
        public static void Inject(IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IBasketRepository, BasketRepository>();
        }
    }
}
