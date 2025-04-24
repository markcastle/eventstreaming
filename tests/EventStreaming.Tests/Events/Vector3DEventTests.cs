using Xunit;
using EventStreaming.Events;

namespace EventStreaming.Tests.Events
{
    /// <summary>
    /// Unit tests for the <see cref="Vector3DEvent"/> class.
    /// </summary>
    public class Vector3DEventTests
    {
        /// <summary>
        /// Verifies that <see cref="Vector3DEvent"/> correctly stores property values.
        /// </summary>
        [Fact]
        public void Properties_Are_Immutable_And_Set()
        {
            var evt = new Vector3DEvent(42, 7, "vector", 1.1, 2.2, 3.3);
            Assert.Equal(42, evt.Sequence);
            Assert.Equal(7, evt.StreamId);
            Assert.Equal("vector", evt.Tag);
            Assert.Equal(1.1, evt.X);
            Assert.Equal(2.2, evt.Y);
            Assert.Equal(3.3, evt.Z);
        }

        /// <summary>
        /// Data-driven test for numeric accuracy of <see cref="Vector3DEvent"/>.
        /// </summary>
        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(-1.5, 2.7, 3.14)]
        [InlineData(double.MaxValue, double.MinValue, 0.0)]
        public void Numeric_Accuracy(double x, double y, double z)
        {
            var evt = new Vector3DEvent(1, 1, "vector", x, y, z);
            Assert.Equal(x, evt.X);
            Assert.Equal(y, evt.Y);
            Assert.Equal(z, evt.Z);
        }
    }
}
