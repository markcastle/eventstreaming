using System;
using System.Collections.Generic;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents an event that encapsulates multiple child events.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class CompositeEvent
    {
        /// <summary>
        /// Gets the collection of child events.
        /// </summary>
        /// <value>The collection of child events.</value>
        public IReadOnlyList<object> Events { get; }

        /// <summary>
        /// Initializes a new <see cref="CompositeEvent"/>.
        /// </summary>
        /// <param name="events">The child events to encapsulate.</param>
        public CompositeEvent(IEnumerable<object> events)
        {
            Events = new List<object>(events ?? new object[0]).AsReadOnly();
        }
    }
}
