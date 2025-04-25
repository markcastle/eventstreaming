using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="QuaternionEvent"/>.
    /// </summary>
    public class QuaternionEventTests
    {
        /// <summary>
        /// Should construct with valid components.
        /// </summary>
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            // Arrange
            double x = 1, y = -2, z = 3.5, w = 0.5;
            // Act
            var evt = new QuaternionEvent(x, y, z, w);
            // Assert
            Assert.Equal(x, evt.X);
            Assert.Equal(y, evt.Y);
            Assert.Equal(z, evt.Z);
            Assert.Equal(w, evt.W);
        }

        /// <summary>
        /// Should allow zero/default values.
        /// </summary>
        [Fact]
        public void Constructor_ZeroValues_PropertiesSetToZero()
        {
            // Act
            var evt = new QuaternionEvent(0, 0, 0, 0);
            // Assert
            Assert.Equal(0, evt.X);
            Assert.Equal(0, evt.Y);
            Assert.Equal(0, evt.Z);
            Assert.Equal(0, evt.W);
        }

        /// <summary>
        /// Should support extreme double values.
        /// </summary>
        [Fact]
        public void Constructor_ExtremeValues_PropertiesSet()
        {
            // Act
            var evt = new QuaternionEvent(double.MaxValue, double.MinValue, double.Epsilon, double.NaN);
            // Assert
            Assert.Equal(double.MaxValue, evt.X);
            Assert.Equal(double.MinValue, evt.Y);
            Assert.Equal(double.Epsilon, evt.Z);
            Assert.True(double.IsNaN(evt.W));
        }
    }
}
