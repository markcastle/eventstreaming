using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ColorEvent"/>.
    /// </summary>
    public class ColorEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new ColorEvent(10, 20, 30, 40);
            Assert.Equal(10, evt.R);
            Assert.Equal(20, evt.G);
            Assert.Equal(30, evt.B);
            Assert.Equal(40, evt.A);
        }

        [Fact]
        public void Constructor_DefaultAlpha_Is255()
        {
            var evt = new ColorEvent(1, 2, 3);
            Assert.Equal(1, evt.R);
            Assert.Equal(2, evt.G);
            Assert.Equal(3, evt.B);
            Assert.Equal(255, evt.A);
        }

        [Fact]
        public void Constructor_MinMaxValues_PropertiesSet()
        {
            var evt = new ColorEvent(byte.MinValue, byte.MaxValue, 0, 255);
            Assert.Equal(0, evt.R);
            Assert.Equal(255, evt.G);
            Assert.Equal(0, evt.B);
            Assert.Equal(255, evt.A);
        }
    }
}
