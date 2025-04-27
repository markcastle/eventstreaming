using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStreaming.InputBuffer;
using Xunit;

namespace EventStreaming.InputBuffer.Tests
{
    public class FilteringInputBufferTests
    {
        [Fact]
        public async Task Filter_Excludes_Events()
        {
            var buffer = new FilteringInputBuffer<int>(filter: i => i % 2 == 0);
            var results = new List<int>();
            buffer.RegisterHandler(i => { results.Add(i); return Task.CompletedTask; });
            for (int i = 0; i < 5; i++)
                buffer.Enqueue(i);
            await Task.Delay(50);
            Assert.Equal(new[] { 0, 2, 4 }, results);
        }

        [Fact]
        public async Task Deduplication_Excludes_Duplicates()
        {
            var buffer = new FilteringInputBuffer<int>(comparer: EqualityComparer<int>.Default);
            var results = new List<int>();
            buffer.RegisterHandler(i => { results.Add(i); return Task.CompletedTask; });
            buffer.Enqueue(1);
            buffer.Enqueue(2);
            buffer.Enqueue(1);
            buffer.Enqueue(2);
            buffer.Enqueue(3);
            await Task.Delay(50);
            Assert.Equal(new[] { 1, 2, 3 }, results);
        }

        [Fact]
        public void RegisterHandler_Throws_On_Null()
        {
            var buffer = new FilteringInputBuffer<int>();
            Assert.Throws<ArgumentNullException>(() => buffer.RegisterHandler(null));
        }
    }
}
