using Aperia.CleanArchitecture.Application.Services;

namespace Aperia.CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// The Date Time Provider
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Services.IDateTimeProvider" />
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        public DateTime Now => DateTime.Now;

        /// <summary>
        /// The UTC now
        /// </summary>
        public DateTime UtcNow => DateTime.UtcNow;

    }
}