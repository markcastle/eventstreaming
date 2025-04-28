using System;
using EventStreaming.Abstractions;
using EventStreaming.Events;

namespace EventStreaming.Factories
{
    /// <summary>
    /// Factory for creating domain events with correct global sequence values.
    /// </summary>
    public class EventFactory
    {
        private readonly IEventSequencer _sequencer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventFactory"/> class.
        /// </summary>
        /// <param name="sequencer">The global event sequencer to inject.</param>
        public EventFactory(IEventSequencer sequencer)
        {
            _sequencer = sequencer ?? throw new ArgumentNullException(nameof(sequencer));
        }

        /// <summary>
        /// Creates a new <see cref="Vector3DEvent"/> with a unique global sequence number.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        /// <returns>A new <see cref="Vector3DEvent"/>.</returns>
        public Vector3DEvent CreateVector3DEvent(int streamId, string tag, double x, double y, double z)
        {
            var seq = _sequencer.NextSequence();
            return new Vector3DEvent(seq, streamId, tag, x, y, z);
        }

        /// <summary>
        /// Creates a new <see cref="RotationEvent"/> with a unique global sequence number.
        /// </summary>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <param name="pitch">The pitch component.</param>
        /// <param name="yaw">The yaw component.</param>
        /// <param name="roll">The roll component.</param>
        /// <returns>A new <see cref="RotationEvent"/>.</returns>
        public RotationEvent CreateRotationEvent(int streamId, string tag, double pitch, double yaw, double roll)
        {
            var seq = _sequencer.NextSequence();
            return new RotationEvent(seq, streamId, tag, pitch, yaw, roll);
        }
    }
}
