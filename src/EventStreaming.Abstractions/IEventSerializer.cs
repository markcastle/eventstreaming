using System;

namespace EventStreaming.Abstractions
{
    /// <summary>
    /// Defines methods for serializing and deserializing event objects.
    /// </summary>
    public interface IEventSerializer
    {
        /// <summary>
        /// Serializes the given event object to a string representation (e.g., JSON, XML).
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="evt">The event instance to serialize.</param>
        /// <returns>The serialized string representation of the event.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="evt"/> is null.</exception>
        string Serialize<TEvent>(TEvent evt) where TEvent : class;

        /// <summary>
        /// Deserializes the given string back into an event object.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="data">The serialized string representation of the event.</param>
        /// <returns>The deserialized event instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="data"/> is null.</exception>
        TEvent Deserialize<TEvent>(string data) where TEvent : class;
    }
}
