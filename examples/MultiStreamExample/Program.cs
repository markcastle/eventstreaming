using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EventStreaming.Events;
using EventStreaming.Factories;

namespace EventStreaming.Examples.MultiStreamExample
{
    /// <summary>
    /// Demonstrates concurrent event creation and correct per-stream sequencing.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point for the multi-stream example.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            var sequencer = new StreamSequencer();
            var factory = new StreamEventFactory(sequencer);
            int[] streamIds = { 1, 2, 3 };
            int eventsPerStream = 5;
            var results = new ConcurrentBag<Vector3DEvent>();

            Parallel.ForEach(streamIds, streamId =>
            {
                for (int i = 0; i < eventsPerStream; i++)
                {
                    var evt = factory.CreateVector3DEvent(streamId, $"stream{streamId}", i * 1.0, i * 2.0, i * 3.0);
                    results.Add(evt);
                }
            });

            foreach (var streamId in streamIds)
            {
                Console.WriteLine($"--- Events for Stream {streamId} ---");
                foreach (var evt in results)
                {
                    if (evt.StreamId == streamId)
                        Console.WriteLine($"Seq={evt.Sequence}, Tag={evt.Tag}, X={evt.X}, Y={evt.Y}, Z={evt.Z}");
                }
            }
        }
    }
}
