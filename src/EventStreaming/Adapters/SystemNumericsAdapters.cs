using System.Numerics;
using Inovus.Messaging.Events;

namespace Inovus.Messaging.Adapters
{
    /// <summary>
    /// Extension methods for converting between <see cref="Vector3"/> and <see cref="Vector3DEvent"/>.
    /// </summary>
    public static class SystemNumericsAdapters
    {
        /// <summary>
        /// Converts a <see cref="Vector3"/> to a <see cref="Vector3DEvent"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3"/> to convert.</param>
        /// <param name="sequence">The event sequence number.</param>
        /// <param name="streamId">The stream identifier.</param>
        /// <param name="tag">The event tag or type identifier.</param>
        /// <returns>A new <see cref="Vector3DEvent"/>.</returns>
        public static Vector3DEvent ToVector3DEvent(this Vector3 vector, long sequence, int streamId, string tag)
        {
            return new Vector3DEvent(sequence, streamId, tag, vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Converts a <see cref="Vector3DEvent"/> to a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="evt">The <see cref="Vector3DEvent"/> to convert.</param>
        /// <returns>A new <see cref="Vector3"/>.</returns>
        public static Vector3 ToVector3(this Vector3DEvent evt)
        {
            return new Vector3((float)evt.X, (float)evt.Y, (float)evt.Z);
        }
    }
}
