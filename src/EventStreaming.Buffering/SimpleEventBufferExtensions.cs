using System;
using System.Threading.Tasks;

namespace EventStreaming.Buffering
{
    /// <summary>
    /// Extension methods and static helpers for creating <see cref="SimpleEventBuffer{T}"/> instances.
    /// </summary>
    public static class SimpleEventBufferExtensions
    {
        /// <summary>
        /// Creates a <see cref="SimpleEventBuffer{T}"/> with an asynchronous processor.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="processor">The async processor delegate.</param>
        /// <returns>A new <see cref="SimpleEventBuffer{T}"/>.</returns>
        public static SimpleEventBuffer<T> CreateAsyncBuffer<T>(Func<T, Task> processor)
            => new(processor);

        /// <summary>
        /// Creates a <see cref="SimpleEventBuffer{T}"/> with a synchronous processor.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="processor">The sync processor delegate.</param>
        /// <returns>A new <see cref="SimpleEventBuffer{T}"/>.</returns>
        public static SimpleEventBuffer<T> CreateSyncBuffer<T>(Action<T> processor)
            => new(processor);
    }
}
