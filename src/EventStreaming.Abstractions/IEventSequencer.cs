using System;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Defines a thread-safe global event sequencer.
    /// </summary>
    public interface IEventSequencer
    {
        /// <summary>
        /// Gets the next available global event sequence number.
        /// </summary>
        long NextSequence();
    }
}
