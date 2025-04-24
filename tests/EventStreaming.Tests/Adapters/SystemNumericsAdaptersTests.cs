using Xunit;
using System.Numerics;
using EventStreaming.Adapters;
using EventStreaming.Events;

namespace EventStreaming.Tests.Adapters
{
    /// <summary>
    /// Unit tests for <see cref="SystemNumericsAdapters"/> extension methods.
    /// </summary>
    public class SystemNumericsAdaptersTests
    {
        /// <summary>
        /// Round-trips a <see cref="Vector3"/> through <see cref="Vector3DEvent"/> and back.
        /// </summary>
        [Theory]
        [InlineData(0f, 0f, 0f)]
        [InlineData(1.1f, 2.2f, 3.3f)]
        [InlineData(-1000f, 0.5f, 9999.9f)]
        public void Vector3_ToEvent_And_Back(float x, float y, float z)
        {
            var vector = new Vector3(x, y, z);
            var evt = vector.ToVector3DEvent(42, 7, "vec");
            var roundTripped = evt.ToVector3();
            Assert.Equal(x, roundTripped.X, 3f);
            Assert.Equal(y, roundTripped.Y, 3f);
            Assert.Equal(z, roundTripped.Z, 3f);
        }

        /// <summary>
        /// Converts a <see cref="Vector3DEvent"/> to <see cref="Vector3"/> and verifies values.
        /// </summary>
        [Fact]
        public void Event_To_Vector3_Values()
        {
            var evt = new Vector3DEvent(99, 5, "vec", 4.5, 5.5, 6.5);
            var vector = evt.ToVector3();
            Assert.Equal(4.5f, vector.X, 3f);
            Assert.Equal(5.5f, vector.Y, 3f);
            Assert.Equal(6.5f, vector.Z, 3f);
        }
    }
}
