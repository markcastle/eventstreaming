using System;
using System.Threading.Tasks;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Defines a generic, thread-safe input buffer for ingesting events from any source.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    public interface IInputBuffer<T>
    {
        /// <summary>
        /// Enqueues an event for processing.
        /// </summary>
        /// <param name="item">The event item to enqueue.</param>
        void Enqueue(T item);

        /// <summary>
        /// Gets the current count of buffered items.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Registers a middleware or handler to process events as they are dequeued.
        /// </summary>
        /// <param name="handler">The delegate to process each event.</param>
        void RegisterHandler(Func<T, Task> handler);
    }
}
