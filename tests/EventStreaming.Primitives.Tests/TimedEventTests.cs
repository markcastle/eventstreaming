using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="TimedEvent{T}"/>.
    /// </summary>
    public class TimedEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var now = DateTime.UtcNow;
            var evt = new TimedEvent<int>(now, 42);
            Assert.Equal(now, evt.Timestamp);
            Assert.Equal(42, evt.Value);
        }

        [Fact]
        public void Constructor_ReferenceType_PropertiesSet()
        {
            var now = DateTime.UtcNow;
            var evt = new TimedEvent<string>(now, "payload");
            Assert.Equal(now, evt.Timestamp);
            Assert.Equal("payload", evt.Value);
        }

        [Fact]
        public void Constructor_NullReferenceType_Allowed()
        {
            var now = DateTime.UtcNow;
            var evt = new TimedEvent<string>(now, null);
            Assert.Equal(now, evt.Timestamp);
            Assert.Null(evt.Value);
        }
    }
}
