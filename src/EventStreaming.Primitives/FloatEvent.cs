using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a float (single-precision) event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class FloatEvent
    {
        /// <summary>
        /// Gets the value of the event.
        /// </summary>
        public float Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatEvent"/> class.
        /// </summary>
        /// <param name="value">The float value.</param>
        public FloatEvent(float value)
        {
            Value = value;
        }
    }
}
