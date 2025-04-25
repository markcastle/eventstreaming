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
        /// Gets the X component of the quaternion.
        /// </summary>
        /// <value>The X component.</value>
        public double X { get; }

        /// <summary>
        /// Gets the Y component of the quaternion.
        /// </summary>
        /// <value>The Y component.</value>
        public double Y { get; }

        /// <summary>
        /// Gets the Z component of the quaternion.
        /// </summary>
        /// <value>The Z component.</value>
        public double Z { get; }

        /// <summary>
        /// Gets the W component of the quaternion.
        /// </summary>
        /// <value>The W component.</value>
        public double W { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuaternionEvent"/> class.
        /// </summary>
        /// <param name="x">The X component of the quaternion.</param>
        /// <param name="y">The Y component of the quaternion.</param>
        /// <param name="z">The Z component of the quaternion.</param>
        /// <param name="w">The W component of the quaternion.</param>
        public QuaternionEvent(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
