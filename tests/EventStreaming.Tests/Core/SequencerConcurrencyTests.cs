using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Inovus.Messaging;

namespace Inovus.Messaging.Tests.Core
{
    /// <summary>
    /// Stress tests for verifying thread-safety and correctness of sequencers under high concurrency.
    /// </summary>
    public class SequencerConcurrencyTests
    {
        /// <summary>
        /// Verifies that <see cref="EventSequencer"/> produces unique, incrementing values under heavy concurrency.
        /// </summary>
        [Fact]
        public void EventSequencer_Is_ThreadSafe_Under_Parallel_Usage()
        {
            const int iterations = 100_000;
            var sequencer = new EventSequencer();
            var results = new ConcurrentBag<long>();

            Parallel.For(0, iterations, _ =>
            {
                results.Add(sequencer.NextSequence());
            });

            Assert.Equal(iterations, results.Distinct().Count());
            Assert.Equal(Enumerable.Range(1, iterations).Select(i => (long)i), results.OrderBy(x => x));
        }

        /// <summary>
        /// Verifies that <see cref="StreamSequencer"/> produces unique, incrementing values per stream under concurrency.
        /// </summary>
        [Fact]
        public void StreamSequencer_Is_ThreadSafe_Per_Stream()
        {
            const int streams = 10;
            const int perStream = 10_000;
            var sequencer = new StreamSequencer();
            var results = new ConcurrentDictionary<int, ConcurrentBag<long>>();

            Parallel.For(0, streams, streamId =>
            {
                var bag = new ConcurrentBag<long>();
                Parallel.For(0, perStream, _ =>
                {
                    bag.Add(sequencer.NextSequence(streamId));
                });
                results[streamId] = bag;
            });

            foreach (var kvp in results)
            {
                Assert.Equal(perStream, kvp.Value.Distinct().Count());
                Assert.Equal(Enumerable.Range(1, perStream).Select(i => (long)i), kvp.Value.OrderBy(x => x));
            }
        }
    }
}
