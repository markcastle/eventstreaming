using System.Numerics;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="SystemNumericsAdapters"/>.
    /// </summary>
    public class SystemNumericsAdaptersTests
    {
        [Fact]
        public void Vector2Event_ToNumerics_And_Back()
        {
            var evt = new Vector2Event(1.5, -2.5);
            Vector2 v = evt.ToNumerics();
            Assert.Equal(1.5f, v.X);
            Assert.Equal(-2.5f, v.Y);
            var evt2 = v.ToEvent();
            Assert.Equal(evt.X, evt2.X);
            Assert.Equal(evt.Y, evt2.Y);
        }

        [Fact]
        public void QuaternionEvent_ToNumerics_And_Back()
        {
            var evt = new QuaternionEvent(1, 2, 3, 4);
            Quaternion q = evt.ToNumerics();
            Assert.Equal(1f, q.X);
            Assert.Equal(2f, q.Y);
            Assert.Equal(3f, q.Z);
            Assert.Equal(4f, q.W);
            var evt2 = q.ToEvent();
            Assert.Equal(evt.X, evt2.X);
            Assert.Equal(evt.Y, evt2.Y);
            Assert.Equal(evt.Z, evt2.Z);
            Assert.Equal(evt.W, evt2.W);
        }
    }
}
