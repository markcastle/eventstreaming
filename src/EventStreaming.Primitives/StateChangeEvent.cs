using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a state change event, holding previous and new state values.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class StateChangeEvent<T>
    {
        /// <summary>Gets the previous state.</summary>
        public T Previous { get; }
        /// <summary>Gets the new state.</summary>
        public T Current { get; }

        /// <summary>
        /// Initializes a new <see cref="StateChangeEvent{T}"/>.
        /// </summary>
        /// <param name="previous">The previous state value.</param>
        /// <param name="current">The new state value.</param>
        public StateChangeEvent(T previous, T current)
        {
            Previous = previous;
            Current = current;
        }
    }
}
