using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="BoolEvent"/>.
    /// </summary>
    public class BoolEventTests
    {
        [Fact]
        public void Constructor_TrueValue_PropertySet()
        {
            var evt = new BoolEvent(true);
            Assert.True(evt.Value);
        }

        [Fact]
        public void Constructor_FalseValue_PropertySet()
        {
            var evt = new BoolEvent(false);
            Assert.False(evt.Value);
        }
    }
}
