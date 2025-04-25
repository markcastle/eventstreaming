using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="CustomPayloadEvent{T}"/>.
    /// </summary>
    public class CustomPayloadEventTests
    {
        [Fact]
        public void Constructor_ValidValue_PropertiesSet()
        {
            var evt = new CustomPayloadEvent<int>(123);
            Assert.Equal(123, evt.Payload);
        }

        [Fact]
        public void Constructor_ReferenceType_PropertiesSet()
        {
            var evt = new CustomPayloadEvent<string>("abc");
            Assert.Equal("abc", evt.Payload);
        }

        [Fact]
        public void Constructor_NullReferenceType_Allowed()
        {
            var evt = new CustomPayloadEvent<object>(null);
            Assert.Null(evt.Payload);
        }
    }
}
