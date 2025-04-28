using System;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Defines a thread-safe sequencer for individual streams.
    /// </summary>
    public interface IStreamSequencer
    {
        /// <summary>
        /// Gets the next sequence number for a specific stream.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        long NextSequence(int streamId);
    }
}
