using System;
using System.Text.Json;
using EventStreaming.Abstractions;

namespace EventStreaming.SystemTextJson
{
    /// <summary>
    /// Provides serialization and deserialization of events using System.Text.Json.
    /// </summary>
    public class SystemTextJsonEventSerializer : IEventSerializer
    {
        /// <inheritdoc />
        public string Serialize<TEvent>(TEvent evt) where TEvent : class
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            return JsonSerializer.Serialize(evt);
        }

        /// <inheritdoc />
        public TEvent Deserialize<TEvent>(string data) where TEvent : class
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return JsonSerializer.Deserialize<TEvent>(data);
        }
    }
}
