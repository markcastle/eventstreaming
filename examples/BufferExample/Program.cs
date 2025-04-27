using System;
using System.Threading.Tasks;
using EventStreaming.Buffering;

namespace BufferExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var buffer = SimpleEventBufferExtensions.CreateAsyncBuffer<string>(async msg =>
            {
                Console.WriteLine($"[Processed] {msg}");
                await Task.Delay(100); // Simulate work
            });

            Console.WriteLine("Enqueuing events...");
            buffer.Enqueue("Event 1");
            buffer.Enqueue("Event 2");
            buffer.Enqueue("Event 3");

            Console.WriteLine("Waiting for processing (press any key to exit)...");
            await Task.Run(() => Console.ReadKey());
        }
    }
}
