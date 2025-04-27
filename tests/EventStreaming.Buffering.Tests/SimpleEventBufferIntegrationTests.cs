using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventStreaming.Buffering;
using Xunit;

namespace EventStreaming.Buffering.Tests
{
    /// <summary>
    /// Example custom event type for integration testing.
    /// </summary>
    public class CustomEvent
    {
        /// <summary>
        /// Event identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Event message.
        /// </summary>
        public string? Message { get; set; }
    }

    /// <summary>
    /// Integration tests for <see cref="SimpleEventBuffer{T}"/> with a custom event type.
    /// </summary>
    public class SimpleEventBufferIntegrationTests : IDisposable
    {
        private SimpleEventBuffer<CustomEvent>? _buffer;
        private readonly List<CustomEvent> _received = new();
        private readonly ManualResetEventSlim _done = new();

        /// <summary>
        /// Verifies sync processing of custom event types.
        /// </summary>
        [Fact]
        public void Buffer_ProcessesCustomEventType_Sync()
        {
            _buffer = new SimpleEventBuffer<CustomEvent>(e =>
            {
                _received.Add(e);
                if (_received.Count == 2) _done.Set();
            });

            _buffer.Enqueue(new CustomEvent { Id = 1, Message = "First" });
            _buffer.Enqueue(new CustomEvent { Id = 2, Message = "Second" });

            Assert.True(_done.Wait(2000));
            Assert.Collection(_received,
                e => Assert.Equal("First", e.Message),
                e => Assert.Equal("Second", e.Message));
        }

        /// <summary>
        /// Verifies async processing of custom event types.
        /// </summary>
        [Fact]
        public async Task Buffer_ProcessesCustomEventType_Async()
        {
            _buffer = new SimpleEventBuffer<CustomEvent>(async e =>
            {
                await Task.Delay(10);
                _received.Add(e);
                if (_received.Count == 2) _done.Set();
            });

            _buffer.Enqueue(new CustomEvent { Id = 100, Message = "Async1" });
            _buffer.Enqueue(new CustomEvent { Id = 200, Message = "Async2" });

            await Task.Run(() => _done.Wait(2000));
            Assert.Collection(_received,
                e => Assert.Equal(100, e.Id),
                e => Assert.Equal(200, e.Id));
        }

        /// <summary>
        /// Disposes of the buffer and resources.
        /// </summary>
        public void Dispose()
        {
            _buffer?.Dispose();
            _done.Dispose();
        }
    }
}
