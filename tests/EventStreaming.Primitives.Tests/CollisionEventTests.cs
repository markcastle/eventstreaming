using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="CollisionEvent"/>.
    /// </summary>
    public class CollisionEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var a = new object();
            var b = new object();
            var point = new Vector2Event(1, 2);
            var evt = new CollisionEvent(a, b, point);
            Assert.Equal(a, evt.EntityA);
            Assert.Equal(b, evt.EntityB);
            Assert.Equal(point, evt.Point);
        }

        [Fact]
        public void Constructor_NullPoint_Allowed()
        {
            var a = new object();
            var b = new object();
            var evt = new CollisionEvent(a, b, null);
            Assert.Equal(a, evt.EntityA);
            Assert.Equal(b, evt.EntityB);
            Assert.Null(evt.Point);
        }

        [Fact]
        public void Constructor_NullEntities_Allowed()
        {
            var evt = new CollisionEvent(null, null, null);
            Assert.Null(evt.EntityA);
            Assert.Null(evt.EntityB);
            Assert.Null(evt.Point);
        }
    }
}
