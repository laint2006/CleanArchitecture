using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aperia.CleanArchitecture.Persistence
{
    /// <summary>
    /// The Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the persistence.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankAccountMgmtDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
            })
            .AddScoped<IBankAccountMgmtDbContext>(sp => sp.GetRequiredService<BankAccountMgmtDbContext>())
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IBankAccountRepository, BankAccountRepository>()
            .AddScoped<IUserRepository, UserRepository>();

            return services;
        }

    }
}