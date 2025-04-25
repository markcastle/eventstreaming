using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a boolean event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class BoolEvent
    {
        /// <summary>
        /// Gets the value of the event.
        /// </summary>
        public bool Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolEvent"/> class.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public BoolEvent(bool value)
        {
            Value = value;
        }
    }
}
