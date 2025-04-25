using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a 2D vector event with double-precision coordinates.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class Vector2Event
    {
        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        /// <value>The X coordinate.</value>
        public double X { get; }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        /// <value>The Y coordinate.</value>
        public double Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Event"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="x"/> or <paramref name="y"/> is NaN (Not a Number), positive infinity, or negative infinity.</exception>
        public Vector2Event(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
