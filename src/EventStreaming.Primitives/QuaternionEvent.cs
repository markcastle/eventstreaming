using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a quaternion event with double-precision components.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class QuaternionEvent
    {
        /// <summary>
        /// Gets the X component.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the Y component.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Gets the Z component.
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Gets the W component.
        /// </summary>
        public double W { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuaternionEvent"/> class.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        /// <param name="w">The W component.</param>
        public QuaternionEvent(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
