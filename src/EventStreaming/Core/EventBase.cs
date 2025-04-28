using System;
using EventStreaming.Abstractions;

namespace EventStreaming
{
    /// <summary>
    /// Provides a base implementation for immutable events in the event stream.
    /// </summary>
    public abstract class EventBase : IEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventBase"/> class.
        /// </summary>
        /// <param name="sequence">The global sequence number.</param>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        protected EventBase(long sequence, int streamId, string tag)
        {
            Sequence = sequence;
            StreamId = streamId;
            Tag = tag;
        }

        /// <inheritdoc />
        public long Sequence { get; }

        /// <inheritdoc />
        public int StreamId { get; }

        /// <inheritdoc />
        public string Tag { get; }
    }
}
