using Xunit;
using EventStreaming.Events;

namespace EventStreaming.Tests.Events
{
    /// <summary>
    /// Unit tests for the <see cref="RotationEvent"/> class.
    /// </summary>
    public class RotationEventTests
    {
        /// <summary>
        /// Verifies that <see cref="RotationEvent"/> correctly stores property values.
        /// </summary>
        [Fact]
        public void Properties_Are_Immutable_And_Set()
        {
            var evt = new RotationEvent(42, 7, "rot", 10.5, 20.5, 30.5);
            Assert.Equal(42, evt.Sequence);
            Assert.Equal(7, evt.StreamId);
            Assert.Equal("rot", evt.Tag);
            Assert.Equal(10.5, evt.Pitch);
            Assert.Equal(20.5, evt.Yaw);
            Assert.Equal(30.5, evt.Roll);
        }

        /// <summary>
        /// Data-driven test for numeric accuracy of <see cref="RotationEvent"/>.
        /// </summary>
        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(-90.0, 180.0, 360.0)]
        [InlineData(double.MaxValue, double.MinValue, 0.0)]
        public void Numeric_Accuracy(double pitch, double yaw, double roll)
        {
            var evt = new RotationEvent(1, 1, "rot", pitch, yaw, roll);
            Assert.Equal(pitch, evt.Pitch);
            Assert.Equal(yaw, evt.Yaw);
            Assert.Equal(roll, evt.Roll);
        }
    }
}
