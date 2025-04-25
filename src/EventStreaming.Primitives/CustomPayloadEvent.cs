using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents an event with a custom payload.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class CustomPayloadEvent<T>
    {
        /// <summary>Gets the payload value.</summary>
        public T Payload { get; }

        /// <summary>
        /// Initializes a new <see cref="CustomPayloadEvent{T}"/>.
        /// </summary>
        /// <param name="payload">The payload value.</param>
        public CustomPayloadEvent(T payload)
        {
            Payload = payload;
        }
    }
}
