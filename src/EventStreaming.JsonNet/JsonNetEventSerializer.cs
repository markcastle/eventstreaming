using System;
using Newtonsoft.Json;
using Inovus.Messaging.Serialization;

namespace Inovus.Messaging.JsonNet
{
    /// <summary>
    /// Provides serialization and deserialization of events using Newtonsoft.Json.
    /// </summary>
    public class JsonNetEventSerializer : IEventSerializer
    {
        /// <inheritdoc />
        public string Serialize<TEvent>(TEvent evt) where TEvent : class
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            return JsonConvert.SerializeObject(evt);
        }

        /// <inheritdoc />
        public TEvent Deserialize<TEvent>(string data) where TEvent : class
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return JsonConvert.DeserializeObject<TEvent>(data);
        }
    }
}
