using System;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;

namespace Inovus.Messaging.Examples.BasicExample
{
    /// <summary>
    /// Demonstrates creating and sequencing events in a single stream.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point for the basic example.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            var sequencer = new EventSequencer();
            var factory = new EventFactory(sequencer);
            int streamId = 1;

            var evt1 = factory.CreateVector3DEvent(streamId, "move", 1.0, 2.0, 3.0);
            var evt2 = factory.CreateVector3DEvent(streamId, "move", 4.0, 5.0, 6.0);
            var evt3 = factory.CreateRotationEvent(streamId, "rotate", 10.0, 20.0, 30.0);

            Console.WriteLine($"Event 1: Seq={evt1.Sequence}, Stream={evt1.StreamId}, Tag={evt1.Tag}, X={evt1.X}, Y={evt1.Y}, Z={evt1.Z}");
            Console.WriteLine($"Event 2: Seq={evt2.Sequence}, Stream={evt2.StreamId}, Tag={evt2.Tag}, X={evt2.X}, Y={evt2.Y}, Z={evt2.Z}");
            Console.WriteLine($"Event 3: Seq={evt3.Sequence}, Stream={evt3.StreamId}, Tag={evt3.Tag}, Pitch={evt3.Pitch}, Yaw={evt3.Yaw}, Roll={evt3.Roll}");
        }
    }
}
