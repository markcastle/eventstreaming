using EventStreaming.Primitives;
using System;

namespace EventStreaming.Builders
{
    /// <summary>
    /// Extension methods for fluent creation of event primitives using the builder pattern.
    /// </summary>
    public static class EventBuilderPrimitivesExtensions
    {
        public static EventBuilder<BoolEvent> WithBool(this EventBuilder<BoolEvent> builder, bool value)
            => builder.WithPayload(new BoolEvent(value));

        public static EventBuilder<IntEvent> WithInt(this EventBuilder<IntEvent> builder, int value)
            => builder.WithPayload(new IntEvent(value));

        public static EventBuilder<FloatEvent> WithFloat(this EventBuilder<FloatEvent> builder, float value)
            => builder.WithPayload(new FloatEvent(value));

        public static EventBuilder<StringEvent> WithString(this EventBuilder<StringEvent> builder, string value)
            => builder.WithPayload(new StringEvent(value));

        public static EventBuilder<ColorEvent> WithColor(this EventBuilder<ColorEvent> builder, byte r, byte g, byte b, byte a = 255)
            => builder.WithPayload(new ColorEvent(r, g, b, a));

        public static EventBuilder<Vector2Event> WithVector2(this EventBuilder<Vector2Event> builder, double x, double y)
            => builder.WithPayload(new Vector2Event(x, y));

        public static EventBuilder<QuaternionEvent> WithQuaternion(this EventBuilder<QuaternionEvent> builder, double x, double y, double z, double w)
            => builder.WithPayload(new QuaternionEvent(x, y, z, w));

        public static EventBuilder<RectEvent> WithRect(this EventBuilder<RectEvent> builder, double x, double y, double width, double height)
            => builder.WithPayload(new RectEvent(x, y, width, height));

        public static EventBuilder<KeyPressEvent> WithKeyPress(this EventBuilder<KeyPressEvent> builder, int keyCode, string keyName, bool pressed)
            => builder.WithPayload(new KeyPressEvent(keyCode, keyName, pressed));

        public static EventBuilder<MouseEvent> WithMouse(this EventBuilder<MouseEvent> builder, int x, int y, int button, bool pressed)
            => builder.WithPayload(new MouseEvent(x, y, button, pressed));

        public static EventBuilder<StateChangeEvent<T>> WithStateChange<T>(this EventBuilder<StateChangeEvent<T>> builder, T previous, T current)
            => builder.WithPayload(new StateChangeEvent<T>(previous, current));

        public static EventBuilder<TimedEvent<T>> WithTimed<T>(this EventBuilder<TimedEvent<T>> builder, DateTime timestamp, T value)
            => builder.WithPayload(new TimedEvent<T>(timestamp, value));

        public static EventBuilder<CommandEvent> WithCommand(this EventBuilder<CommandEvent> builder, string command, object payload = null)
            => builder.WithPayload(new CommandEvent(command, payload));

        public static EventBuilder<CustomPayloadEvent<T>> WithCustomPayload<T>(this EventBuilder<CustomPayloadEvent<T>> builder, T payload)
            => builder.WithPayload(new CustomPayloadEvent<T>(payload));

        public static EventBuilder<CollisionEvent> WithCollision(this EventBuilder<CollisionEvent> builder, object entityA, object entityB, object? point = null)
            => builder.WithPayload(new CollisionEvent(entityA, entityB, point));
    }
}
