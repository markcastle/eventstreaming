using System;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Represents a simple, thread-safe buffer for events of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The event type to buffer.</typeparam>
    public interface ISimpleEventBuffer<T>
    {
        /// <summary>
        /// Enqueues an item into the buffer.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        void Enqueue(T item);

        /// <summary>
        /// Gets the current count of items in the buffer.
        /// </summary>
        int Count { get; }
    }
}
