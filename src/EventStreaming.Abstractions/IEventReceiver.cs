using System.Threading.Tasks;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Defines a contract for receiving events from an external source and pushing them into an input buffer.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    public interface IEventReceiver<T>
    {
        /// <summary>
        /// Starts receiving events and pushing them into the provided input buffer.
        /// </summary>
        /// <param name="buffer">The buffer to receive events.</param>
        /// <returns>A task representing the asynchronous receive operation.</returns>
        Task StartAsync(IInputBuffer<T> buffer);

        /// <summary>
        /// Stops receiving events.
        /// </summary>
        /// <returns>A task representing the asynchronous stop operation.</returns>
        Task StopAsync();
    }
}
