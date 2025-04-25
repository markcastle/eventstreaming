using System;
using System.Collections.Generic;
using System.Linq;

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

    public static class EventBuilder
    {
        /// <summary>
        /// Starts a new composite event builder with the first event.
        /// </summary>
        public static CompositeEventBuilder StartWith(object firstEvent)
        {
            return new CompositeEventBuilder().Add(firstEvent);
        }
    }

    /// <summary>
    /// Fluent builder for composite events.
    /// </summary>
    public class CompositeEventBuilder
    {
        private readonly List<object> _events = new List<object>();
        private readonly Dictionary<string, object> _metadata = new Dictionary<string, object>();
        private Action<Exception> _onError;

        public IReadOnlyList<object> Events => _events;
        public IReadOnlyDictionary<string, object> Metadata => _metadata;

        public CompositeEventBuilder Add(object evt)
        {
            _events.Add(evt);
            return this;
        }

        public CompositeEventBuilder AddMetadata(string key, object value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            _metadata[key] = value;
            return this;
        }

        public CompositeEventBuilder OnError(Action<Exception> handler)
        {
            _onError = handler;
            return this;
        }

        public void InvokeError(Exception ex)
        {
            _onError?.Invoke(ex);
        }

        public CompositeEvent Build()
        {
            return new CompositeEvent(_events, _metadata);
        }
    }

    /// <summary>
    /// Represents a composite event with metadata.
    /// </summary>
    public class CompositeEvent
    {
        public IReadOnlyList<object> Events { get; }
        public IReadOnlyDictionary<string, object> Metadata { get; }

        public CompositeEvent(IEnumerable<object> events, IDictionary<string, object> metadata)
        {
            Events = events.ToList();
            Metadata = new Dictionary<string, object>(metadata);
        }
    }
}
