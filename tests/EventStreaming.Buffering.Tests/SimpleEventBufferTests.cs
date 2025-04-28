using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventStreaming.Buffering;
using Xunit;

namespace EventStreaming.Buffering.Tests
{
    /// <summary>
    /// Unit tests for <see cref="SimpleEventBuffer{T}"/> covering sync/async, count, and error scenarios.
    /// </summary>
    public class SimpleEventBufferTests : IDisposable
    {
        private SimpleEventBuffer<int>? _buffer;
        private readonly List<int> _processed = new();
        private readonly List<int> _asyncProcessed = new();
        private readonly ManualResetEventSlim _syncDone = new();
        private readonly ManualResetEventSlim _asyncDone = new();

        /// <summary>
        /// Verifies that items enqueued are processed by a synchronous processor.
        /// </summary>
        [Fact]
        public void Enqueue_SyncProcessor_ProcessesItems()
        {
            _buffer = new SimpleEventBuffer<int>(i =>
            {
                _processed.Add(i);
                if (_processed.Count == 3) _syncDone.Set();
            });

            _buffer.Enqueue(1);
            _buffer.Enqueue(2);
            _buffer.Enqueue(3);

            Assert.True(_syncDone.Wait(2000));
            Assert.Equal(new[] { 1, 2, 3 }, _processed);
        }

        /// <summary>
        /// Verifies that items enqueued are processed by an asynchronous processor.
        /// </summary>
        [Fact]
        public async Task Enqueue_AsyncProcessor_ProcessesItems()
        {
            _buffer = new SimpleEventBuffer<int>(async i =>
            {
                await Task.Delay(10);
                _asyncProcessed.Add(i);
                if (_asyncProcessed.Count == 3) _asyncDone.Set();
            });

            _buffer.Enqueue(10);
            _buffer.Enqueue(20);
            _buffer.Enqueue(30);

            await Task.Run(() => _asyncDone.Wait(2000));
            Assert.Equal(new[] { 10, 20, 30 }, _asyncProcessed);
        }

        /// <summary>
        /// Verifies that the Count property reflects the number of items in the buffer.
        /// </summary>
        [Fact]
        public void Count_ReturnsCorrectValue()
        {
            using var block = new ManualResetEventSlim(false);
            _buffer = new SimpleEventBuffer<int>(_ => block.Wait());
            Assert.Equal(0, _buffer.Count);
            _buffer.Enqueue(1);
            Assert.Equal(1, _buffer.Count);
            _buffer.Enqueue(2);
            Assert.Equal(2, _buffer.Count);
            block.Set(); // Allow processing to complete
        }

        /// <summary>
        /// Ensures that exceptions during processing do not stop the buffer.
        /// </summary>
        [Fact]
        public void Buffer_HandlesExceptionsAndContinues()
        {
            int processed = 0;
            _buffer = new SimpleEventBuffer<int>(i =>
            {
                processed++;
                if (i == 2) throw new InvalidOperationException();
            });
            _buffer.Enqueue(1);
            _buffer.Enqueue(2);
            _buffer.Enqueue(3);
            // Wait up to 2 seconds for all items to be processed
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (processed < 3 && sw.ElapsedMilliseconds < 2000)
            {
                Thread.Sleep(10);
            }
            Assert.True(processed >= 3);
        }

        /// <summary>
        /// Disposes of the buffer and resources.
        /// </summary>
        public void Dispose()
        {
            _buffer?.Dispose();
            _syncDone.Dispose();
            _asyncDone.Dispose();
        }
    }
}
