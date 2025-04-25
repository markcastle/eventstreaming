using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="CommandEvent"/>.
    /// </summary>
    public class CommandEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new CommandEvent("Start", 123);
            Assert.Equal("Start", evt.Command);
            Assert.Equal(123, evt.Payload);
        }

        [Fact]
        public void Constructor_NullPayload_Allowed()
        {
            var evt = new CommandEvent("Stop", null);
            Assert.Equal("Stop", evt.Command);
            Assert.Null(evt.Payload);
        }

        [Fact]
        public void Constructor_NullCommand_SetsToEmpty()
        {
            var evt = new CommandEvent(null, "data");
            Assert.Equal(string.Empty, evt.Command);
            Assert.Equal("data", evt.Payload);
        }
    }
}
