using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a rectangle event with double-precision coordinates and size.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class RectEvent
    {
        /// <summary>
        /// Gets the X coordinate of the rectangle's origin.
        /// </summary>
        /// <value>The X coordinate.</value>
        public double X { get; }
        /// <summary>
        /// Gets the Y coordinate of the rectangle's origin.
        /// </summary>
        /// <value>The Y coordinate.</value>
        public double Y { get; }
        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        /// <value>The width.</value>
        public double Width { get; }
        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        /// <value>The height.</value>
        public double Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectEvent"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public RectEvent(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
