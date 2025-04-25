using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="IntEvent"/>.
    /// </summary>
    public class IntEventTests
    {
        [Fact]
        public void Constructor_ValidValue_PropertySet()
        {
            int value = 42;
            var evt = new IntEvent(value);
            Assert.Equal(value, evt.Value);
        }

        [Fact]
        public void Constructor_ZeroValue_PropertySetToZero()
        {
            var evt = new IntEvent(0);
            Assert.Equal(0, evt.Value);
        }

        [Fact]
        public void Constructor_ExtremeValues_PropertiesSet()
        {
            var evt = new IntEvent(int.MaxValue);
            Assert.Equal(int.MaxValue, evt.Value);
            evt = new IntEvent(int.MinValue);
            Assert.Equal(int.MinValue, evt.Value);
        }
    }
}
