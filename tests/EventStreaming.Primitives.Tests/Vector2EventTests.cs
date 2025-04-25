using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Vector2Event"/>.
    /// </summary>
    public class Vector2EventTests
    {
        /// <summary>
        /// Should construct with valid coordinates.
        /// </summary>
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            // Arrange
            double x = 1.5, y = -2.7;
            // Act
            var evt = new Vector2Event(x, y);
            // Assert
            Assert.Equal(x, evt.X);
            Assert.Equal(y, evt.Y);
        }

        /// <summary>
        /// Should allow zero/default values.
        /// </summary>
        [Fact]
        public void Constructor_ZeroValues_PropertiesSetToZero()
        {
            // Act
            var evt = new Vector2Event(0, 0);
            // Assert
            Assert.Equal(0, evt.X);
            Assert.Equal(0, evt.Y);
        }

        /// <summary>
        /// Should support extreme double values.
        /// </summary>
        [Fact]
        public void Constructor_ExtremeValues_PropertiesSet()
        {
            // Act
            var evt = new Vector2Event(double.MaxValue, double.MinValue);
            // Assert
            Assert.Equal(double.MaxValue, evt.X);
            Assert.Equal(double.MinValue, evt.Y);
        }
    }
}
