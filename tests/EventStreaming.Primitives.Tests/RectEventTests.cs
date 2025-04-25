using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="RectEvent"/>.
    /// </summary>
    public class RectEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new RectEvent(1.1, 2.2, 3.3, 4.4);
            Assert.Equal(1.1, evt.X);
            Assert.Equal(2.2, evt.Y);
            Assert.Equal(3.3, evt.Width);
            Assert.Equal(4.4, evt.Height);
        }

        [Fact]
        public void Constructor_ZeroWidthHeight_Allowed()
        {
            var evt = new RectEvent(0, 0, 0, 0);
            Assert.Equal(0, evt.Width);
            Assert.Equal(0, evt.Height);
        }

        [Fact]
        public void Constructor_NegativeWidthHeight_Allowed()
        {
            var evt = new RectEvent(1, 1, -5, -10);
            Assert.Equal(-5, evt.Width);
            Assert.Equal(-10, evt.Height);
        }

        [Fact]
        public void Constructor_LargeValues_Allowed()
        {
            var evt = new RectEvent(double.MaxValue, double.MinValue, double.MaxValue, double.MinValue);
            Assert.Equal(double.MaxValue, evt.X);
            Assert.Equal(double.MinValue, evt.Y);
            Assert.Equal(double.MaxValue, evt.Width);
            Assert.Equal(double.MinValue, evt.Height);
        }
    }
}
