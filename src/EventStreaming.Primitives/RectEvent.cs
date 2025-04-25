using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a rectangle event with double-precision coordinates and size.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class RectEvent
    {
        /// <summary>Gets the X coordinate of the rectangle's origin.</summary>
        public double X { get; }
        /// <summary>Gets the Y coordinate of the rectangle's origin.</summary>
        public double Y { get; }
        /// <summary>Gets the width of the rectangle.</summary>
        public double Width { get; }
        /// <summary>Gets the height of the rectangle.</summary>
        public double Height { get; }

        /// <summary>
        /// Initializes a new <see cref="RectEvent"/>.
        /// </summary>
        /// <param name="x">The X coordinate of the origin.</param>
        /// <param name="y">The Y coordinate of the origin.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public RectEvent(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
