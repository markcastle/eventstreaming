using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="KeyPressEvent"/>.
    /// </summary>
    public class KeyPressEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new KeyPressEvent(65, "A", true);
            Assert.Equal(65, evt.KeyCode);
            Assert.Equal("A", evt.KeyName);
            Assert.True(evt.Pressed);
        }

        [Fact]
        public void Constructor_EmptyKeyName_Allowed()
        {
            var evt = new KeyPressEvent(13, "", false);
            Assert.Equal(13, evt.KeyCode);
            Assert.Equal("", evt.KeyName);
            Assert.False(evt.Pressed);
        }

        [Fact]
        public void Constructor_NullKeyName_SetsToEmpty()
        {
            var evt = new KeyPressEvent(42, null, true);
            Assert.Equal(42, evt.KeyCode);
            Assert.Equal(string.Empty, evt.KeyName);
            Assert.True(evt.Pressed);
        }
    }
}
