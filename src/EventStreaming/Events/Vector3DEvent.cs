using System;

namespace EventStreaming.Events
{
    /// <summary>
    /// Represents a 3D vector event with double-precision components.
    /// </summary>
    public sealed class Vector3DEvent : EventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3DEvent"/> class.
        /// </summary>
        /// <param name="sequence">The global sequence number.</param>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Vector3DEvent(long sequence, int streamId, string tag, double x, double y, double z)
            : base(sequence, streamId, tag)
        {
            X = x;
            Y = y;
            Z = z;
        }

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
    }
}
