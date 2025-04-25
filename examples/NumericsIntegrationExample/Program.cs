using System;
using System.Numerics;
using EventStreaming.Adapters;
using EventStreaming.Events;
using EventStreaming.Factories;

namespace EventStreaming.Examples.NumericsIntegrationExample
{
    /// <summary>
    /// Demonstrates integration with System.Numerics.Vector3 and event adapters.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point for the numerics integration example.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            var sequencer = new EventSequencer();
            var factory = new EventFactory(sequencer);
            int streamId = 42;

            // Create a Vector3 and convert to Vector3DEvent using extension
            Vector3 position = new Vector3(7.7f, 8.8f, 9.9f);
            var evt = position.ToVector3DEvent(sequencer.NextSequence(), streamId, "unity-pos");

            Console.WriteLine($"Original Vector3: X={position.X}, Y={position.Y}, Z={position.Z}");
            Console.WriteLine($"Event: Seq={evt.Sequence}, Stream={evt.StreamId}, Tag={evt.Tag}, X={evt.X}, Y={evt.Y}, Z={evt.Z}");

            // Convert back to Vector3
            Vector3 roundTrip = evt.ToVector3();
            Console.WriteLine($"Round-tripped Vector3: X={roundTrip.X}, Y={roundTrip.Y}, Z={roundTrip.Z}");

            // --- Primitives <-> System.Numerics Demo ---
            Console.WriteLine("\n--- Primitives <-> System.Numerics Demo ---");
            PrimitivesNumericsDemo.Run();
        }
    }
}
