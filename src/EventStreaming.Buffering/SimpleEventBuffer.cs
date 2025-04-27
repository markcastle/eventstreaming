using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using EventStreaming.Core;

namespace EventStreaming.Buffering
{
    /// <summary>
    /// A thread-safe, generic event buffer using a <see cref="ConcurrentQueue{T}"/> and background worker for processing.
    /// Supports both synchronous and asynchronous processing delegates.
    /// </summary>
    /// <typeparam name="T">The event type to buffer.</typeparam>
    public class SimpleEventBuffer<T> : ISimpleEventBuffer<T>, IDisposable
    {
        private readonly ConcurrentQueue<T> _queue = new();
        private readonly SemaphoreSlim _signal = new(0);
        private readonly CancellationTokenSource _cts = new();
        private readonly Func<T, Task>? _asyncProcessor;
        private readonly Action<T>? _syncProcessor;
        private readonly Task _worker;

        /// <summary>
        /// Initializes a new instance with an asynchronous processor.
        /// </summary>
        /// <param name="asyncProcessor">The async delegate to process items.</param>
        public SimpleEventBuffer(Func<T, Task> asyncProcessor)
        {
            _asyncProcessor = asyncProcessor ?? throw new ArgumentNullException(nameof(asyncProcessor));
            _worker = Task.Run(ProcessAsync);
        }

        /// <summary>
        /// Initializes a new instance with a synchronous processor.
        /// </summary>
        /// <param name="syncProcessor">The sync delegate to process items.</param>
        public SimpleEventBuffer(Action<T> syncProcessor)
        {
            _syncProcessor = syncProcessor ?? throw new ArgumentNullException(nameof(syncProcessor));
            _worker = Task.Run(ProcessAsync);
        }

        /// <inheritdoc />
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            _signal.Release();
        }

        /// <inheritdoc />
        public int Count => _queue.Count;

        private async Task ProcessAsync()
        {
            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    await _signal.WaitAsync(_cts.Token).ConfigureAwait(false);
                    if (_queue.TryDequeue(out var item))
                    {
                        if (_asyncProcessor != null)
                            await _asyncProcessor(item).ConfigureAwait(false);
                        else if (_syncProcessor != null)
                            _syncProcessor(item);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    // Reason: Swallow or log exception; buffer should keep running.
                    // TODO: Add logging or error handling as needed.
                }
            }
        }

        /// <summary>
        /// Disposes the buffer and stops processing.
        /// </summary>
        public void Dispose()
        {
            _cts.Cancel();
            _signal.Release();
            try { _worker.Wait(); } catch { }
            _cts.Dispose();
            _signal.Dispose();
        }
    }
}
