using System;
using System.Threading;
using EventStreaming.Abstractions;

namespace EventStreaming
{
    /// <summary>
    /// Provides a thread-safe, lock-free global event sequencer.
    /// </summary>
    public class EventSequencer : IEventSequencer
    {
        private long _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSequencer"/> class.
        /// </summary>
        /// <param name="initialValue">The initial sequence value. Defaults to 1.</param>
        public EventSequencer(long initialValue = 1)
        {
            _current = initialValue - 1;
        }

        /// <inheritdoc />
        public long NextSequence()
        {
            // Reason: Interlocked.Increment provides atomic, lock-free increment for concurrency.
            return Interlocked.Increment(ref _current);
        }
    }
}
