using System;
using Inovus.Messaging.Events;

namespace Inovus.Messaging.Factories
{
    /// <summary>
    /// Factory for creating domain events with correct per-stream sequence values.
    /// </summary>
    public class StreamEventFactory
    {
        private readonly IStreamSequencer _sequencer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamEventFactory"/> class.
        /// </summary>
        /// <param name="sequencer">The per-stream event sequencer to inject.</param>
        public StreamEventFactory(IStreamSequencer sequencer)
        {
            _sequencer = sequencer ?? throw new ArgumentNullException(nameof(sequencer));
        }

        /// <summary>
        /// Creates a new <see cref="Vector3DEvent"/> with a unique per-stream sequence number.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        /// <returns>A new <see cref="Vector3DEvent"/>.</returns>
        public Vector3DEvent CreateVector3DEvent(int streamId, string tag, double x, double y, double z)
        {
            var seq = _sequencer.NextSequence(streamId);
            return new Vector3DEvent(seq, streamId, tag, x, y, z);
        }

        /// <summary>
        /// Creates a new <see cref="RotationEvent"/> with a unique per-stream sequence number.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="pitch">The pitch component.</param>
        /// <param name="yaw">The yaw component.</param>
        /// <param name="roll">The roll component.</param>
        /// <returns>A new <see cref="RotationEvent"/>.</returns>
        public RotationEvent CreateRotationEvent(int streamId, string tag, double pitch, double yaw, double roll)
        {
            var seq = _sequencer.NextSequence(streamId);
            return new RotationEvent(seq, streamId, tag, pitch, yaw, roll);
        }
    }
}
