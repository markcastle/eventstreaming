using System;

namespace EventStreaming.Builders
{
    /// <summary>
    /// Fluent builder for creating events with a payload.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    public class EventBuilder<T>
    {
        private T _payload;
        private bool _payloadSet;

        /// <summary>
        /// Sets the payload for the event.
        /// </summary>
        /// <param name="payload">The event payload.</param>
        /// <returns>The builder instance.</returns>
        public EventBuilder<T> WithPayload(T payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            _payload = payload;
            _payloadSet = true;
            return this;
        }

        /// <summary>
        /// Builds the event instance.
        /// </summary>
        /// <returns>The event instance.</returns>
        public Event<T> Build()
        {
            if (!_payloadSet)
                throw new InvalidOperationException("Payload must be set before building the event.");
            return new Event<T>(_payload);
        }
    }

    /// <summary>
    /// Simple event record for demonstration.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    public class Event<T>
    {
        /// <summary>
        /// The payload for the event.
        /// </summary>
        public T Payload { get; }

        /// <summary>
        /// Initializes a new event instance.
        /// </summary>
        /// <param name="payload">The event payload.</param>
        public Event(T payload)
        {
            Payload = payload;
        }
    }
}
