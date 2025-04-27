using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStreaming.InputBuffer;
using Xunit;

namespace EventStreaming.InputBuffer.Tests
{
    public class BatchingInputBufferTests
    {
        [Fact]
        public async Task Batching_Processes_Events_In_Batches()
        {
            var buffer = new BatchingInputBuffer<int>(batchSize: 3);
            var batches = new List<IReadOnlyList<int>>();
            buffer.RegisterHandler(batch => { batches.Add(batch); return Task.CompletedTask; });

            for (int i = 0; i < 7; i++)
                buffer.Enqueue(i);

            await Task.Delay(100);
            Assert.Equal(3, batches.Count); // 3 batches: [0,1,2], [3,4,5], [6]
            Assert.Equal(3, batches[0].Count);
            Assert.Equal(3, batches[1].Count);
            Assert.Equal(1, batches[2].Count);
            Assert.Equal(Enumerable.Range(0, 7), batches.SelectMany(x => x));
        }

        [Fact]
        public void Throws_On_Invalid_BatchSize()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BatchingInputBuffer<int>(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new BatchingInputBuffer<int>(-1));
        }

        [Fact]
        public void RegisterHandler_Throws_On_Null()
        {
            var buffer = new BatchingInputBuffer<int>(2);
            Assert.Throws<ArgumentNullException>(() => buffer.RegisterHandler(null));
        }
    }
}
