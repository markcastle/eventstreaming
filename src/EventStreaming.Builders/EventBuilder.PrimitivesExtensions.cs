using EventStreaming.Primitives;
using System;

namespace EventStreaming.Builders
{
    /// <summary>
    /// Extension methods for fluent creation of event primitives using the builder pattern.
    /// </summary>
    public static class EventBuilderPrimitivesExtensions
    {
        /// <summary>
        /// Sets the payload as a BoolEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="value">The boolean value to set as the payload.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<BoolEvent> WithBool(this EventBuilder<BoolEvent> builder, bool value)
            => builder.WithPayload(new BoolEvent(value));

        /// <summary>
        /// Sets the payload as an IntEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="value">The integer value to set as the payload.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<IntEvent> WithInt(this EventBuilder<IntEvent> builder, int value)
            => builder.WithPayload(new IntEvent(value));

        /// <summary>
        /// Sets the payload as a FloatEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="value">The float value to set as the payload.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<FloatEvent> WithFloat(this EventBuilder<FloatEvent> builder, float value)
            => builder.WithPayload(new FloatEvent(value));

        /// <summary>
        /// Sets the payload as a StringEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="value">The string value to set as the payload.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<StringEvent> WithString(this EventBuilder<StringEvent> builder, string value)
            => builder.WithPayload(new StringEvent(value));

        /// <summary>
        /// Sets the payload as a ColorEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="r">The red component of the color.</param>
        /// <param name="g">The green component of the color.</param>
        /// <param name="b">The blue component of the color.</param>
        /// <param name="a">The alpha component of the color (default is 255).</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<ColorEvent> WithColor(this EventBuilder<ColorEvent> builder, byte r, byte g, byte b, byte a = 255)
            => builder.WithPayload(new ColorEvent(r, g, b, a));

        /// <summary>
        /// Sets the payload as a Vector2Event.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="x">The x component of the vector.</param>
        /// <param name="y">The y component of the vector.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<Vector2Event> WithVector2(this EventBuilder<Vector2Event> builder, double x, double y)
            => builder.WithPayload(new Vector2Event(x, y));

        /// <summary>
        /// Sets the payload as a QuaternionEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="x">The x component of the quaternion.</param>
        /// <param name="y">The y component of the quaternion.</param>
        /// <param name="z">The z component of the quaternion.</param>
        /// <param name="w">The w component of the quaternion.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<QuaternionEvent> WithQuaternion(this EventBuilder<QuaternionEvent> builder, double x, double y, double z, double w)
            => builder.WithPayload(new QuaternionEvent(x, y, z, w));

        /// <summary>
        /// Sets the payload as a RectEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="x">The x coordinate of the rectangle.</param>
        /// <param name="y">The y coordinate of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<RectEvent> WithRect(this EventBuilder<RectEvent> builder, double x, double y, double width, double height)
            => builder.WithPayload(new RectEvent(x, y, width, height));

        /// <summary>
        /// Sets the payload as a KeyPressEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="keyCode">The key code of the key press event.</param>
        /// <param name="keyName">The name of the key that was pressed.</param>
        /// <param name="pressed">Whether the key was pressed or released.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<KeyPressEvent> WithKeyPress(this EventBuilder<KeyPressEvent> builder, int keyCode, string keyName, bool pressed)
            => builder.WithPayload(new KeyPressEvent(keyCode, keyName, pressed));

        /// <summary>
        /// Sets the payload as a MouseEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="x">The x coordinate of the mouse event.</param>
        /// <param name="y">The y coordinate of the mouse event.</param>
        /// <param name="button">The mouse button that was pressed or released.</param>
        /// <param name="pressed">Whether the mouse button was pressed or released.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<MouseEvent> WithMouse(this EventBuilder<MouseEvent> builder, int x, int y, int button, bool pressed)
            => builder.WithPayload(new MouseEvent(x, y, button, pressed));

        /// <summary>
        /// Sets the payload as a StateChangeEvent.
        /// </summary>
        /// <typeparam name="T">The type of the state.</typeparam>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="previous">The previous state.</param>
        /// <param name="current">The current state.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<StateChangeEvent<T>> WithStateChange<T>(this EventBuilder<StateChangeEvent<T>> builder, T previous, T current)
            => builder.WithPayload(new StateChangeEvent<T>(previous, current));

        /// <summary>
        /// Sets the payload as a TimedEvent.
        /// </summary>
        /// <typeparam name="T">The type of the timed event value.</typeparam>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="timestamp">The timestamp of the timed event.</param>
        /// <param name="value">The value of the timed event.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<TimedEvent<T>> WithTimed<T>(this EventBuilder<TimedEvent<T>> builder, DateTime timestamp, T value)
            => builder.WithPayload(new TimedEvent<T>(timestamp, value));

        /// <summary>
        /// Sets the payload as a CommandEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="payload">The payload to pass to the command (optional).</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<CommandEvent> WithCommand(this EventBuilder<CommandEvent> builder, string command, object payload = null)
            => builder.WithPayload(new CommandEvent(command, payload));

        /// <summary>
        /// Sets the payload as a CustomPayloadEvent.
        /// </summary>
        /// <typeparam name="T">The type of the custom payload.</typeparam>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="payload">The custom payload.</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<CustomPayloadEvent<T>> WithCustomPayload<T>(this EventBuilder<CustomPayloadEvent<T>> builder, T payload)
            => builder.WithPayload(new CustomPayloadEvent<T>(payload));

        /// <summary>
        /// Sets the payload as a CollisionEvent.
        /// </summary>
        /// <param name="builder">The EventBuilder instance.</param>
        /// <param name="entityA">The first entity involved in the collision.</param>
        /// <param name="entityB">The second entity involved in the collision.</param>
        /// <param name="point">The point of collision (optional).</param>
        /// <returns>The EventBuilder instance with the payload set.</returns>
        public static EventBuilder<CollisionEvent> WithCollision(this EventBuilder<CollisionEvent> builder, object entityA, object entityB, object? point = null)
            => builder.WithPayload(new CollisionEvent(entityA, entityB, point));
    }
}
