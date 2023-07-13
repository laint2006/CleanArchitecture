using System.Text.Json.Serialization;
using Aperia.CleanArchitecture.Presentation.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Aperia.CleanArchitecture.Presentation
{
    /// <summary>
    /// The Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the presentation.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    })
                    .AddApplicationPart(typeof(DependencyInjection).Assembly);

            services.AddSingleton<ProblemDetailsFactory, ApplicationProblemDetailsFactory>();

            return services;
        }

        /// <summary>
        /// Adds the middlewares.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ApplicationMiddleware>();

            return applicationBuilder;
        }
    }
}