using System;
using System.Numerics;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Extension methods for adapting between Event primitives and System.Numerics types.
    /// </summary>
    public static class SystemNumericsAdapters
    {
        /// <summary>
        /// Converts a <see cref="Vector2Event"/> to <see cref="Vector2"/>.
        /// </summary>
        public static Vector2 ToNumerics(this Vector2Event evt)
            => new Vector2((float)evt.X, (float)evt.Y);

        /// <summary>
        /// Converts a <see cref="Vector2"/> to <see cref="Vector2Event"/>.
        /// </summary>
        public static Vector2Event ToEvent(this Vector2 v)
            => new Vector2Event(v.X, v.Y);

        /// <summary>
        /// Converts a <see cref="QuaternionEvent"/> to <see cref="Quaternion"/>.
        /// </summary>
        public static Quaternion ToNumerics(this QuaternionEvent evt)
            => new Quaternion((float)evt.X, (float)evt.Y, (float)evt.Z, (float)evt.W);

        /// <summary>
        /// Converts a <see cref="Quaternion"/> to <see cref="QuaternionEvent"/>.
        /// </summary>
        public static QuaternionEvent ToEvent(this Quaternion q)
            => new QuaternionEvent(q.X, q.Y, q.Z, q.W);
    }
}
