using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a collision event between two entities.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class CollisionEvent
    {
        /// <summary>
        /// Gets the first entity involved in the collision.
        /// </summary>
        /// <value>The first entity.</value>
        public object EntityA { get; }
        /// <summary>
        /// Gets the second entity involved in the collision.
        /// </summary>
        /// <value>The second entity.</value>
        public object EntityB { get; }
        /// <summary>
        /// Gets the collision point (optional, e.g., as a Vector2Event).
        /// </summary>
        /// <value>The collision point, or null if not set.</value>
        public object Point { get; }

        /// <summary>
        /// Initializes a new <see cref="CollisionEvent"/>.
        /// </summary>
        /// <param name="entityA">The first entity.</param>
        /// <param name="entityB">The second entity.</param>
        /// <param name="point">The collision point (optional).</param>
        public CollisionEvent(object entityA, object entityB, object point = null)
        {
            EntityA = entityA;
            EntityB = entityB;
            Point = point;
        }
    }
}
