using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents an integer event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class IntEvent
    {
        /// <summary>
        /// Gets the value of the event.
        /// </summary>
        /// <value>The integer value of the event.</value>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntEvent"/> class.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public IntEvent(int value)
        {
            Value = value;
        }
    }
}
