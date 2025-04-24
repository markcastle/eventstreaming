using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Inovus.Messaging
{
    /// <summary>
    /// Provides a thread-safe sequencer for individual event streams.
    /// </summary>
    public class StreamSequencer : IStreamSequencer
    {
        private readonly ConcurrentDictionary<int, long> _streamSequences = new ConcurrentDictionary<int, long>();

        /// <summary>
        /// Gets the next sequence number for a specific stream.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        /// <returns>The next sequence number for the stream.</returns>
        public long NextSequence(int streamId)
        {
            // Reason: Ensures atomic increment per stream using lock-free concurrency.
            return _streamSequences.AddOrUpdate(streamId, 1, (id, current) => Interlocked.Increment(ref current));
        }
    }
}
