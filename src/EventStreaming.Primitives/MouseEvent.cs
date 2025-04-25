using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a mouse event (position, button, action).
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class MouseEvent
    {
        /// <summary>Gets the X position of the mouse.</summary>
        public double X { get; }
        /// <summary>Gets the Y position of the mouse.</summary>
        public double Y { get; }
        /// <summary>Gets the mouse button (e.g., 0=left, 1=right, 2=middle).</summary>
        public int Button { get; }
        /// <summary>Gets a value indicating whether the button is pressed (true) or released (false).</summary>
        public bool Pressed { get; }

        /// <summary>
        /// Initializes a new <see cref="MouseEvent"/>.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="button">The mouse button.</param>
        /// <param name="pressed">Whether the button is pressed.</param>
        public MouseEvent(double x, double y, int button, bool pressed)
        {
            X = x;
            Y = y;
            Button = button;
            Pressed = pressed;
        }
    }
}
