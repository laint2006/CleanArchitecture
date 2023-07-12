namespace Aperia.CleanArchitecture.Domain.Primitives
{
    /// <summary>
    /// The IDomainEvent interface
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        object? Payload { get; set; }
    }
}