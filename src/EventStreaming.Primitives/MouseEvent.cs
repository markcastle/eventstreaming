using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a mouse event (position, button, action).
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class MouseEvent
    {
        /// <summary>
        /// Gets the mouse X coordinate.
        /// </summary>
        /// <value>The X coordinate of the mouse.</value>
        public double X { get; }
        /// <summary>
        /// Gets the mouse Y coordinate.
        /// </summary>
        /// <value>The Y coordinate of the mouse.</value>
        public double Y { get; }
        /// <summary>
        /// Gets the mouse button that was pressed or released.
        /// </summary>
        /// <value>The mouse button.</value>
        public string Button { get; }
        /// <summary>
        /// Gets a value indicating whether the button was pressed (true) or released (false).
        /// </summary>
        /// <value>True if pressed; false if released.</value>
        public bool Pressed { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEvent"/> class.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <param name="button">The mouse button.</param>
        /// <param name="pressed">True if pressed; false if released.</param>
        public MouseEvent(double x, double y, string button, bool pressed)
        {
            X = x;
            Y = y;
            Button = button;
            Pressed = pressed;
        }
    }
}
