using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Aperia.CleanArchitecture.Presentation.Middlewares
{
    /// <summary>
    /// The Application Middleware
    /// </summary>
    public class ApplicationMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ApplicationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }

    }
}