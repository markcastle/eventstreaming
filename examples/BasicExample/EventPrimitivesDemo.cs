using System;
using EventStreaming.Builders;
using EventStreaming.Primitives;
using PrimitiveCompositeEvent = EventStreaming.Primitives.CompositeEvent;

namespace EventStreaming.Examples.BasicExample
{
    /// <summary>
    /// Demonstrates usage of event primitives.
    /// </summary>
    internal static class EventPrimitivesDemo
    {
        public static void Run()
        {
            // Vector2Event
            var v2 = new Vector2Event(3.14, 2.72);
            Console.WriteLine($"Vector2Event: X={v2.X}, Y={v2.Y}");

            // QuaternionEvent
            var quat = new QuaternionEvent(1, 0, 0, 0);
            Console.WriteLine($"QuaternionEvent: X={quat.X}, Y={quat.Y}, Z={quat.Z}, W={quat.W}");

            // FloatEvent
            var f = new FloatEvent(1.23f);
            Console.WriteLine($"FloatEvent: Value={f.Value}");

            // IntEvent
            var i = new IntEvent(42);
            Console.WriteLine($"IntEvent: Value={i.Value}");

            // BoolEvent
            var b = new BoolEvent(true);
            Console.WriteLine($"BoolEvent: Value={b.Value}");

            // StringEvent
            var s = new StringEvent("hello");
            Console.WriteLine($"StringEvent: Value={s.Value}");

            // ColorEvent
            var color = new ColorEvent(255, 100, 50, 128);
            Console.WriteLine($"ColorEvent: R={color.R}, G={color.G}, B={color.B}, A={color.A}");

            // RectEvent
            var rect = new RectEvent(1, 2, 10, 20);
            Console.WriteLine($"RectEvent: X={rect.X}, Y={rect.Y}, W={rect.Width}, H={rect.Height}");

            // KeyPressEvent
            var key = new KeyPressEvent(65, "A", true);
            Console.WriteLine($"KeyPressEvent: Code={key.KeyCode}, Name={key.KeyName}, Pressed={key.Pressed}");

            // MouseEvent
            var mouse = new MouseEvent(100, 200, 0, true);
            Console.WriteLine($"MouseEvent: X={mouse.X}, Y={mouse.Y}, Button={mouse.Button}, Pressed={mouse.Pressed}");

            // CompositeEvent
            var composite = new PrimitiveCompositeEvent(new object[] { v2, f, s });
            Console.WriteLine($"CompositeEvent: Count={composite.Events.Count}");

            // StateChangeEvent
            var stateChange = new StateChangeEvent<string>("old", "new");
            Console.WriteLine($"StateChangeEvent: Prev={stateChange.Previous}, Curr={stateChange.Current}");

            // TimedEvent
            var timed = new TimedEvent<int>(DateTime.UtcNow, 123);
            Console.WriteLine($"TimedEvent: Time={timed.Timestamp}, Value={timed.Value}");

            // CommandEvent
            var cmd = new CommandEvent("Start", new { Info = 1 });
            Console.WriteLine($"CommandEvent: Cmd={cmd.Command}, Payload={cmd.Payload}");

            // CollisionEvent
            var collision = new CollisionEvent("Player", "Wall", v2);
            Console.WriteLine($"CollisionEvent: A={collision.EntityA}, B={collision.EntityB}, Point={collision.Point}");

            // ErrorEvent
            var error = new ErrorEvent("Something went wrong", 500, null);
            Console.WriteLine($"ErrorEvent: Msg={error.Message}, Code={error.Code}");

            // CustomPayloadEvent
            var custom = new CustomPayloadEvent<double[]>(new[] { 1.0, 2.0, 3.0 });
            Console.WriteLine($"CustomPayloadEvent: Payload=[{string.Join(",", custom.Payload)}]");

            // --- Fluent EventBuilder usage for primitives ---
            var builtBool = new EventBuilder<BoolEvent>().WithBool(true).Build();
            Console.WriteLine($"[Builder] BoolEvent: Value={builtBool.Payload.Value}");

            var builtInt = new EventBuilder<IntEvent>().WithInt(123).Build();
            Console.WriteLine($"[Builder] IntEvent: Value={builtInt.Payload.Value}");

            var builtColor = new EventBuilder<ColorEvent>().WithColor(10, 20, 30, 40).Build();
            Console.WriteLine($"[Builder] ColorEvent: R={builtColor.Payload.R}, G={builtColor.Payload.G}, B={builtColor.Payload.B}, A={builtColor.Payload.A}");

            var builtVec = new EventBuilder<Vector2Event>().WithVector2(1.5, -2.5).Build();
            Console.WriteLine($"[Builder] Vector2Event: X={builtVec.Payload.X}, Y={builtVec.Payload.Y}");

            var builtQuat = new EventBuilder<QuaternionEvent>().WithQuaternion(1, 2, 3, 4).Build();
            Console.WriteLine($"[Builder] QuaternionEvent: X={builtQuat.Payload.X}, Y={builtQuat.Payload.Y}, Z={builtQuat.Payload.Z}, W={builtQuat.Payload.W}");

            var builtState = new EventBuilder<StateChangeEvent<string>>().WithStateChange("A", "B").Build();
            Console.WriteLine($"[Builder] StateChangeEvent: Prev={builtState.Payload.Previous}, Curr={builtState.Payload.Current}");

            var builtTimed = new EventBuilder<TimedEvent<int>>().WithTimed(DateTime.UtcNow, 42).Build();
            Console.WriteLine($"[Builder] TimedEvent: Time={builtTimed.Payload.Timestamp}, Value={builtTimed.Payload.Value}");

            var builtCustom = new EventBuilder<CustomPayloadEvent<double>>().WithCustomPayload(3.14).Build();
            Console.WriteLine($"[Builder] CustomPayloadEvent: Payload={builtCustom.Payload.Payload}");

            var builtCollision = new EventBuilder<CollisionEvent>().WithCollision("A", "B", null).Build();
            Console.WriteLine($"[Builder] CollisionEvent: A={builtCollision.Payload.EntityA}, B={builtCollision.Payload.EntityB}, Point={builtCollision.Payload.Point}");
        }
    }
}
