using System;
using System.Threading;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.InputBuffer
{
    /// <summary>
    /// A mock event receiver that generates events at a configurable interval for testing purposes.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    public class MockEventReceiver<T> : IEventReceiver<T>
    {
        private readonly Func<int, T> _eventFactory;
        private readonly int _count;
        private readonly TimeSpan _interval;
        private CancellationTokenSource? _cts;
        private Task? _worker;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockEventReceiver{T}"/> class.
        /// </summary>
        /// <param name="eventFactory">A factory function to create events, given an index.</param>
        /// <param name="count">The total number of events to generate.</param>
        /// <param name="interval">Time between events.</param>
        public MockEventReceiver(Func<int, T> eventFactory, int count, TimeSpan interval)
        {
            _eventFactory = eventFactory ?? throw new ArgumentNullException(nameof(eventFactory));
            _count = count;
            _interval = interval;
        }

        /// <inheritdoc />
        public Task StartAsync(IInputBuffer<T> buffer)
        {
            if (_worker != null && !_worker.IsCompleted)
                throw new InvalidOperationException("MockEventReceiver is already running.");

            _cts = new CancellationTokenSource();
            _worker = Task.Run(async () =>
            {
                for (int i = 0; i < _count && !_cts.Token.IsCancellationRequested; i++)
                {
                    buffer.Enqueue(_eventFactory(i));
                    await Task.Delay(_interval, _cts.Token).ConfigureAwait(false);
                }
            }, _cts.Token);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task StopAsync()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                if (_worker != null)
                {
                    try { await _worker.ConfigureAwait(false); } catch { }
                }
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}
