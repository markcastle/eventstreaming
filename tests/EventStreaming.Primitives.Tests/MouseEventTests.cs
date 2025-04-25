using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="MouseEvent"/>.
    /// </summary>
    public class MouseEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new MouseEvent(10.5, 20.5, 0, true);
            Assert.Equal(10.5, evt.X);
            Assert.Equal(20.5, evt.Y);
            Assert.Equal(0, evt.Button);
            Assert.True(evt.Pressed);
        }

        [Fact]
        public void Constructor_NegativeButton_Allowed()
        {
            var evt = new MouseEvent(0, 0, -1, false);
            Assert.Equal(-1, evt.Button);
            Assert.False(evt.Pressed);
        }

        [Fact]
        public void Constructor_LargeValues_Allowed()
        {
            var evt = new MouseEvent(double.MaxValue, double.MinValue, int.MaxValue, true);
            Assert.Equal(double.MaxValue, evt.X);
            Assert.Equal(double.MinValue, evt.Y);
            Assert.Equal(int.MaxValue, evt.Button);
            Assert.True(evt.Pressed);
        }
    }
}
