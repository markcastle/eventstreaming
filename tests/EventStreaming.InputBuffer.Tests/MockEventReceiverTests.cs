using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreaming.InputBuffer;
using Xunit;

namespace EventStreaming.InputBuffer.Tests
{
    public class MockEventReceiverTests
    {
        [Fact]
        public async Task MockEventReceiver_Generates_Events()
        {
            var buffer = new InputBuffer<int>();
            var received = new List<int>();
            buffer.RegisterHandler(i => { received.Add(i); return Task.CompletedTask; });
            var receiver = new MockEventReceiver<int>(i => i, count: 5, interval: TimeSpan.FromMilliseconds(10));
            await receiver.StartAsync(buffer);
            await Task.Delay(70);
            await receiver.StopAsync();
            Assert.Equal(new[] { 0, 1, 2, 3, 4 }, received);
        }

        [Fact]
        public async Task StopAsync_Can_Be_Called_Multiple_Times()
        {
            var buffer = new InputBuffer<int>();
            var receiver = new MockEventReceiver<int>(i => i, count: 1, interval: TimeSpan.FromMilliseconds(1));
            await receiver.StartAsync(buffer);
            await receiver.StopAsync();
            await receiver.StopAsync(); // Should not throw
        }

        [Fact]
        public async Task StartAsync_Throws_If_Already_Running()
        {
            var buffer = new InputBuffer<int>();
            var receiver = new MockEventReceiver<int>(i => i, count: 2, interval: TimeSpan.FromMilliseconds(1));
            await receiver.StartAsync(buffer);
            await Assert.ThrowsAsync<InvalidOperationException>(() => receiver.StartAsync(buffer));
            await receiver.StopAsync();
        }
    }
}
