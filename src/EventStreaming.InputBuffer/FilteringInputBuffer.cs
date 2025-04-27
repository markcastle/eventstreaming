using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.InputBuffer
{
    /// <summary>
    /// An input buffer that filters and deduplicates incoming events before processing.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    public class FilteringInputBuffer<T> : IInputBuffer<T>
    {
        private readonly ConcurrentQueue<T> _queue = new();
        private readonly List<Func<T, Task>> _handlers = new();
        private readonly object _handlerLock = new();
        private readonly Func<T, bool>? _filter;
        private readonly IEqualityComparer<T>? _comparer;
        private readonly HashSet<T>? _seen;
        private volatile bool _processing;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilteringInputBuffer{T}"/> class.
        /// </summary>
        /// <param name="filter">Optional predicate to filter events. Only events where this returns true are processed.</param>
        /// <param name="comparer">Optional equality comparer for deduplication. If supplied, duplicate events are ignored.</param>
        public FilteringInputBuffer(Func<T, bool>? filter = null, IEqualityComparer<T>? comparer = null)
        {
            _filter = filter;
            _comparer = comparer;
            if (comparer != null)
                _seen = new HashSet<T>(comparer);
        }

        /// <summary>
        /// Gets the current count of buffered items.
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// Enqueues an event for processing if it passes filter and deduplication.
        /// </summary>
        /// <param name="item">The event item to enqueue.</param>
        public void Enqueue(T item)
        {
            if (_filter != null && !_filter(item))
                return;
            if (_seen != null && !_seen.Add(item))
                return; // Duplicate, skip
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
            if (!_queue.IsEmpty)
                StartProcessing();
        }
    }
}
