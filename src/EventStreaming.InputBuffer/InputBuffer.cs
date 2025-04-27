using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.InputBuffer
{
    /// <summary>
    /// Provides a generic, thread-safe input buffer for ingesting and processing events from any source.
    /// Supports registering multiple asynchronous handlers (middleware) for event processing.
    /// </summary>
    /// <typeparam name="T">The event type to buffer and process.</typeparam>
    public class InputBuffer<T> : IInputBuffer<T>
    {
        /// <summary>
        /// The underlying concurrent queue for buffered events.
        /// </summary>
        private readonly ConcurrentQueue<T> _queue = new();
        /// <summary>
        /// The list of registered asynchronous event handlers (middleware).
        /// </summary>
        private readonly List<Func<T, Task>> _handlers = new();
        /// <summary>
        /// Lock object for thread-safe handler registration.
        /// </summary>
        private readonly object _handlerLock = new();
        /// <summary>
        /// Indicates whether the buffer is currently processing events.
        /// </summary>
        private volatile bool _processing;

        /// <summary>
        /// Gets the current count of buffered items.
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// Enqueues an event for processing by registered handlers.
        /// </summary>
        /// <param name="item">The event item to enqueue.</param>
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            StartProcessing();
        }

        /// <summary>
        /// Registers an asynchronous handler (middleware) to process events as they are dequeued.
        /// </summary>
        /// <param name="handler">The delegate to process each event.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="handler"/> is null.</exception>
        public void RegisterHandler(Func<T, Task> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            lock (_handlerLock)
            {
                _handlers.Add(handler);
            }
            StartProcessing();
        }

        /// <summary>
        /// Starts processing events in the buffer if not already processing.
        /// </summary>
        private void StartProcessing()
        {
            if (_processing) return;
            _processing = true;
            _ = Task.Run(ProcessQueueAsync);
        }

        /// <summary>
        /// Asynchronously processes all events in the buffer using registered handlers.
        /// Ensures all middleware are invoked for each event.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ProcessQueueAsync()
        {
            while (_queue.TryDequeue(out var item))
            {
                List<Func<T, Task>> handlersCopy;
                lock (_handlerLock)
                {
                    handlersCopy = new List<Func<T, Task>>(_handlers);
                }
                foreach (var handler in handlersCopy)
                {
                    try
                    {
                        await handler(item).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        // TODO: Add logging or error handling as needed.
                    }
                }
            }
            _processing = false;
            // Double-check for race: if new items arrived, restart processing
            if (!_queue.IsEmpty)
                StartProcessing();
        }
    }
}
