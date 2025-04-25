using System;
using System.Numerics;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Extension methods for adapting between Event primitives and System.Numerics types.
    /// These adapters enable seamless conversion between domain event types and popular numerics types for interoperability.
    /// </summary>
    public static class SystemNumericsAdapters
    {
        /// <summary>
        /// Converts a <see cref="Vector2Event"/> to <see cref="Vector2"/>.
        /// </summary>
        /// <param name="evt">The source <see cref="Vector2Event"/>.</param>
        /// <returns>A <see cref="Vector2"/> with the same coordinates.</returns>
        public static Vector2 ToNumerics(this Vector2Event evt)
            => new Vector2((float)evt.X, (float)evt.Y);

        /// <summary>
        /// Converts a <see cref="Vector2"/> to <see cref="Vector2Event"/>.
        /// </summary>
        /// <param name="v">The source <see cref="Vector2"/>.</param>
        /// <returns>A <see cref="Vector2Event"/> with the same coordinates.</returns>
        public static Vector2Event ToEvent(this Vector2 v)
            => new Vector2Event(v.X, v.Y);

        /// <summary>
        /// Converts a <see cref="QuaternionEvent"/> to <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="evt">The source <see cref="QuaternionEvent"/>.</param>
        /// <returns>A <see cref="Quaternion"/> with the same components.</returns>
        public static Quaternion ToNumerics(this QuaternionEvent evt)
            => new Quaternion((float)evt.X, (float)evt.Y, (float)evt.Z, (float)evt.W);

        /// <summary>
        /// Converts a <see cref="Quaternion"/> to <see cref="QuaternionEvent"/>.
        /// </summary>
        /// <param name="q">The source <see cref="Quaternion"/>.</param>
        /// <returns>A <see cref="QuaternionEvent"/> with the same components.</returns>
        public static QuaternionEvent ToEvent(this Quaternion q)
            => new QuaternionEvent(q.X, q.Y, q.Z, q.W);
    }
}
