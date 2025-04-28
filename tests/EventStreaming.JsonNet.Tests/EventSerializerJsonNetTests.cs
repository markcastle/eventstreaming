using System;
using Newtonsoft.Json;
using Xunit;
using EventStreaming.Abstractions;
using EventStreaming.Events;
using EventStreaming.JsonNet;

namespace EventStreaming.JsonNet.Tests
{
    /// <summary>
    /// Unit tests for the JsonNetEventSerializer implementation.
    /// </summary>
    public class EventSerializerJsonNetTests
    {
        /// <summary>
        /// Tests serialization and deserialization of a simple event.
        /// </summary>
        [Fact]
        public void Serialize_And_Deserialize_Vector3DEvent_RoundTrips()
        {
            var serializer = new JsonNetEventSerializer();
            var evt = new Vector3DEvent(42, 1, "test", 1.1, 2.2, 3.3);
            var json = serializer.Serialize(evt);
            var deserialized = serializer.Deserialize<Vector3DEvent>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(evt.Sequence, deserialized.Sequence);
            Assert.Equal(evt.StreamId, deserialized.StreamId);
            Assert.Equal(evt.Tag, deserialized.Tag);
            Assert.Equal(evt.X, deserialized.X);
            Assert.Equal(evt.Y, deserialized.Y);
            Assert.Equal(evt.Z, deserialized.Z);
        }

        /// <summary>
        /// Ensures serialization throws on null input.
        /// </summary>
        [Fact]
        public void Serialize_Null_Throws()
        {
            var serializer = new JsonNetEventSerializer();
            Assert.Throws<ArgumentNullException>(() => serializer.Serialize<Vector3DEvent>(null));
        }

        /// <summary>
        /// Ensures deserialization throws on null input.
        /// </summary>
        [Fact]
        public void Deserialize_Null_Throws()
        {
            var serializer = new JsonNetEventSerializer();
            Assert.Throws<ArgumentNullException>(() => serializer.Deserialize<Vector3DEvent>(null));
        }

        /// <summary>
        /// Ensures deserialization throws on malformed JSON.
        /// </summary>
        [Fact]
        public void Deserialize_MalformedJson_Throws()
        {
            var serializer = new JsonNetEventSerializer();
            Assert.Throws<JsonReaderException>(() => serializer.Deserialize<Vector3DEvent>("{not a valid json}"));
        }

        /// <summary>
        /// Ensures deserialization returns null for empty JSON string.
        /// </summary>
        [Fact]
        public void Deserialize_Empty_ReturnsNull()
        {
            var serializer = new JsonNetEventSerializer();
            var result = serializer.Deserialize<Vector3DEvent>("");
            Assert.Null(result);
        }
    }
}
