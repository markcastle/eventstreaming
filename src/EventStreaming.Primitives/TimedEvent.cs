using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents an event with an associated timestamp.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class TimedEvent<T>
    {
        /// <summary>
        /// Gets the timestamp of the event (UTC).
        /// </summary>
        /// <value>The timestamp (UTC).</value>
        public DateTime Timestamp { get; }
        /// <summary>
        /// Gets the payload or value associated with the event.
        /// </summary>
        /// <value>The value associated with the event.</value>
        public T Value { get; }

        /// <summary>
        /// Initializes a new <see cref="TimedEvent{T}"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp (UTC).</param>
        /// <param name="value">The value associated with the event.</param>
        public TimedEvent(DateTime timestamp, T value)
        {
            Timestamp = timestamp;
            Value = value;
        }
    }
}
