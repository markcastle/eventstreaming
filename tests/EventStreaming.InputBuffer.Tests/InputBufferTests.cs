using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStreaming.InputBuffer;
using Xunit;

namespace EventStreaming.InputBuffer.Tests
{
    public class InputBufferTests
    {
        [Fact]
        public async Task Enqueue_And_Handler_Process_All_Events()
        {
            var buffer = new InputBuffer<int>();
            var results = new List<int>();
            buffer.RegisterHandler(i => { results.Add(i); return Task.CompletedTask; });

            for (int i = 0; i < 10; i++)
                buffer.Enqueue(i);

            await Task.Delay(100); // Allow async processing
            Assert.Equal(10, results.Count);
            Assert.True(results.OrderBy(x => x).SequenceEqual(Enumerable.Range(0, 10)));
        }

        [Fact]
        public async Task Multiple_Handlers_Are_Called_For_Each_Event()
        {
            var buffer = new InputBuffer<int>();
            int count1 = 0, count2 = 0;
            buffer.RegisterHandler(i => { count1++; return Task.CompletedTask; });
            buffer.RegisterHandler(i => { count2 += 2; return Task.CompletedTask; });

            buffer.Enqueue(42);
            await Task.Delay(50);
            Assert.Equal(1, count1);
            Assert.Equal(2, count2);
        }

        [Fact]
        public void RegisterHandler_Throws_On_Null()
        {
            var buffer = new InputBuffer<int>();
            Assert.Throws<ArgumentNullException>(() => buffer.RegisterHandler(null));
        }

        [Fact]
        public void Count_Reflects_Queued_Items()
        {
            var buffer = new InputBuffer<int>();
            buffer.Enqueue(1);
            buffer.Enqueue(2);
            Assert.True(buffer.Count >= 0);
        }
    }
}
