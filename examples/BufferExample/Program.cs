using System;
using System.Threading;
using System.Threading.Tasks;
using EventStreaming.Buffering;
using EventStreaming.Builders;
using EventStreaming.Primitives;
using PrimitiveCompositeEvent = EventStreaming.Primitives.CompositeEvent;

namespace BufferExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--stress")
            {
                await RunStressTest();
                return;
            }

            // Create a buffer for composite events
            using var buffer = SimpleEventBufferExtensions.CreateAsyncBuffer<PrimitiveCompositeEvent>(async composite =>
            {
                Console.WriteLine($"[CompositeEvent] Contains {composite.Events.Count} child events:");
                foreach (var child in composite.Events)
                {
                    switch (child)
                    {
                        case StateChangeEvent<string> state:
                            Console.WriteLine($"  StateChange: '{state.Previous}' -> '{state.Current}'");
                            break;
                        case string msg:
                            Console.WriteLine($"  Message: {msg}");
                            break;
                        default:
                            Console.WriteLine($"  Unknown event type: {child.GetType().Name}");
                            break;
                    }
                }
                await Task.Delay(100); // Simulate work
            });

            Console.WriteLine("Building and enqueuing composite events...");

            // Build a composite event using the builder
            var composite1 = new PrimitiveCompositeEvent(new object[]
            {
                new StateChangeEvent<string>("Idle", "Processing"),
                "Started processing batch #1"
            });

            var composite2 = new PrimitiveCompositeEvent(new object[]
            {
                new StateChangeEvent<string>("Processing", "Completed"),
                "Batch #1 complete"
            });

            buffer.Enqueue(composite1);
            buffer.Enqueue(composite2);
        }

        private static async Task RunStressTest()
        {
            const int totalEvents = 5_000_000;
            int processed = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var tcs = new TaskCompletionSource<bool>();

            var buffer = SimpleEventBufferExtensions.CreateAsyncBuffer<int>(async i =>
            {
                if (Interlocked.Increment(ref processed) == totalEvents)
                    tcs.TrySetResult(true);
                await Task.Yield();
            });

            Console.WriteLine($"Enqueuing {totalEvents:N0} events...");
            for (int i = 0; i < totalEvents; i++)
                buffer.Enqueue(i);

            Console.WriteLine("Waiting for all events to be processed...");
            await tcs.Task;
            sw.Stop();

            Console.WriteLine($"Processed {totalEvents:N0} events in {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Throughput: {totalEvents / Math.Max(1, sw.Elapsed.TotalSeconds):N0} events/sec");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            buffer.Dispose(); 
        }
    }
}
