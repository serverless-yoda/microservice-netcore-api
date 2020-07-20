using CodeCheater.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CodeCheater.Domain
{
    public static class DomainDependencies
    {
        public static void Inject(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<ConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddTransient<IRedisUnitOfWork, RedisUnitOfWork>();
        }
    }
}
