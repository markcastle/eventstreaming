using System;
using System.Numerics;
using EventStreaming.Primitives;

namespace EventStreaming.Examples.NumericsIntegrationExample
{
    /// <summary>
    /// Demonstrates conversion between event primitives and System.Numerics types.
    /// </summary>
    internal static class PrimitivesNumericsDemo
    {
        public static void Run()
        {
            // Vector2Event <-> Vector2
            var v2event = new Vector2Event(1.1, 2.2);
            Vector2 v2 = v2event.ToNumerics();
            Console.WriteLine($"Vector2Event -> Vector2: X={v2.X}, Y={v2.Y}");
            var v2event2 = v2.ToEvent();
            Console.WriteLine($"Vector2 -> Vector2Event: X={v2event2.X}, Y={v2event2.Y}");

            // QuaternionEvent <-> Quaternion
            var qevent = new QuaternionEvent(0.1, 0.2, 0.3, 0.4);
            Quaternion q = qevent.ToNumerics();
            Console.WriteLine($"QuaternionEvent -> Quaternion: X={q.X}, Y={q.Y}, Z={q.Z}, W={q.W}");
            var qevent2 = q.ToEvent();
            Console.WriteLine($"Quaternion -> QuaternionEvent: X={qevent2.X}, Y={qevent2.Y}, Z={qevent2.Z}, W={qevent2.W}");
        }
    }
}
