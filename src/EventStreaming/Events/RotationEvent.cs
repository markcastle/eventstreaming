using System;

namespace Inovus.Messaging.Events
{
    /// <summary>
    /// Represents a rotation event with double-precision pitch, yaw, and roll components.
    /// </summary>
    public sealed class RotationEvent : EventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotationEvent"/> class.
        /// </summary>
        /// <param name="sequence">The global sequence number.</param>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="pitch">The pitch component.</param>
        /// <param name="yaw">The yaw component.</param>
        /// <param name="roll">The roll component.</param>
        public RotationEvent(long sequence, int streamId, string tag, double pitch, double yaw, double roll)
            : base(sequence, streamId, tag)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        /// <summary>
        /// Gets the pitch component.
        /// </summary>
        public double Pitch { get; }

        /// <summary>
        /// Gets the yaw component.
        /// </summary>
        public double Yaw { get; }

        /// <summary>
        /// Gets the roll component.
        /// </summary>
        public double Roll { get; }
    }
}
