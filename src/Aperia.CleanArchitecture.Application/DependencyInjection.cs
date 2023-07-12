using Aperia.CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Aperia.CleanArchitecture.Application
{
    /// <summary>
    /// The Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            })
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}