using System;
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

            Console.WriteLine("Waiting for processing (press any key to exit)...");
            await Task.Run(() => Console.ReadKey());
        }
    }
}
