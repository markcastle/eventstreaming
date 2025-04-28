using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.InputBuffer
{
    /// <summary>
    /// An input buffer that batches incoming events and processes them in groups for efficiency.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    public class BatchingInputBuffer<T> : IInputBuffer<IReadOnlyList<T>>
    {
        private readonly ConcurrentQueue<T> _queue = new();
        private readonly List<Func<IReadOnlyList<T>, Task>> _handlers = new();
        private readonly object _handlerLock = new();
        private readonly int _batchSize;
        private volatile bool _processing;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchingInputBuffer{T}"/> class.
        /// </summary>
        /// <param name="batchSize">The maximum number of events per batch.</param>
        public BatchingInputBuffer(int batchSize)
        {
            if (batchSize <= 0) throw new ArgumentOutOfRangeException(nameof(batchSize));
            _batchSize = batchSize;
        }

        /// <summary>
        /// Gets the current count of buffered items (not batches).
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// Enqueues an event for batching and processing.
        /// </summary>
        /// <param name="item">The event item to enqueue.</param>
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            StartProcessing();
        }

        /// <summary>
        /// Enqueues a batch of events for processing.
        /// </summary>
        /// <param name="items">The batch of event items to enqueue.</param>
        public void Enqueue(IReadOnlyList<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                Enqueue(item);
        }

        /// <summary>
        /// Registers a handler to process batches of events.
        /// </summary>
        /// <param name="handler">The delegate to process each batch.</param>
        public void RegisterHandler(Func<IReadOnlyList<T>, Task> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            lock (_handlerLock)
            {
                _handlers.Add(handler);
            }
            StartProcessing();
        }

        private void StartProcessing()
        {
            if (_processing) return;
            _processing = true;
            _ = Task.Run(ProcessQueueAsync);
        }

        private async Task ProcessQueueAsync()
        {
            while (_queue.Count > 0)
            {
                var batch = new List<T>(_batchSize);
                while (batch.Count < _batchSize && _queue.TryDequeue(out var item))
                {
                    batch.Add(item);
                }
                if (batch.Count == 0) break;

                List<Func<IReadOnlyList<T>, Task>> handlersCopy;
                lock (_handlerLock)
                {
                    handlersCopy = new List<Func<IReadOnlyList<T>, Task>>(_handlers);
                }
                foreach (var handler in handlersCopy)
                {
                    try
                    {
                        await handler(batch).ConfigureAwait(false);
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
