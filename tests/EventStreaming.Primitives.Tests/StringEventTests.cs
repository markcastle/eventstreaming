using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="StringEvent"/>.
    /// </summary>
    public class StringEventTests
    {
        [Fact]
        public void Constructor_ValidValue_PropertySet()
        {
            var evt = new StringEvent("hello");
            Assert.Equal("hello", evt.Value);
        }

        [Fact]
        public void Constructor_EmptyString_PropertySet()
        {
            var evt = new StringEvent("");
            Assert.Equal("", evt.Value);
        }

        [Fact]
        public void Constructor_NullValue_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new StringEvent(null));
        }
    }
}
