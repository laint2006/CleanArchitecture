using Aperia.CleanArchitecture.Domain.Common;
using System.Text.Json;

namespace Aperia.CleanArchitecture.Domain.Events.Entities
{
    /// <summary>
    /// The Event
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Domain.Common.Entity{Int64}" />
    /// <seealso cref="Aperia.CleanArchitecture.Domain.Common.IAuditableEntity" />
    public class Event : Entity<long>, IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        public string? EventType { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        public string? Payload { get; set; }

        /// <summary>
        /// Gets or sets the is dispatched.
        /// </summary>
        public bool IsDispatched { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="payload">The payload.</param>
        private Event(string eventType, string? payload)
            : base(default)
        {
            this.EventType = eventType;
            this.Payload = payload;
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="dispatched">The dispatched</param>
        /// <returns></returns>
        public static Event Create(string eventType, string? payload, bool dispatched = false)
        {
            return new Event(eventType, payload)
            {
                IsDispatched = dispatched
            };
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="dispatched">The dispatched</param>
        /// <returns></returns>
        public static Event Create(string eventType, object? payload, bool dispatched = false)
        {
            var payloadAsJson = payload is null ? null : JsonSerializer.Serialize(payload);

            return new Event(eventType, payloadAsJson)
            {
                IsDispatched = dispatched
            };
        }

    }
}