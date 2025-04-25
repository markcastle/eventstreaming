using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="FloatEvent"/>.
    /// </summary>
    public class FloatEventTests
    {
        [Fact]
        public void Constructor_ValidValue_PropertySet()
        {
            float value = 3.14f;
            var evt = new FloatEvent(value);
            Assert.Equal(value, evt.Value);
        }

        [Fact]
        public void Constructor_ZeroValue_PropertySetToZero()
        {
            var evt = new FloatEvent(0f);
            Assert.Equal(0f, evt.Value);
        }

        [Fact]
        public void Constructor_ExtremeValues_PropertiesSet()
        {
            var evt = new FloatEvent(float.MaxValue);
            Assert.Equal(float.MaxValue, evt.Value);
            evt = new FloatEvent(float.MinValue);
            Assert.Equal(float.MinValue, evt.Value);
            evt = new FloatEvent(float.NaN);
            Assert.True(float.IsNaN(evt.Value));
        }
    }
}
