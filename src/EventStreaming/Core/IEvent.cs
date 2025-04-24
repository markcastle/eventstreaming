using System;

namespace Inovus.Messaging
{
    /// <summary>
    /// Represents an immutable event in the event stream.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the global sequence number for this event.
        /// </summary>
        long Sequence { get; }

        /// <summary>
        /// Gets the stream identifier this event belongs to.
        /// </summary>
        int StreamId { get; }

        /// <summary>
        /// Gets the event tag or type identifier.
        /// </summary>
        string Tag { get; }
    }
}
