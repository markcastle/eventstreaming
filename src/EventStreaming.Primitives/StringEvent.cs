using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a string event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class StringEvent
    {
        /// <summary>
        /// Gets the value of the event.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringEvent"/> class.
        /// </summary>
        /// <param name="value">The string value.</param>
        public StringEvent(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
