using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="StateChangeEvent{T}"/>.
    /// </summary>
    public class StateChangeEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var evt = new StateChangeEvent<int>(1, 2);
            Assert.Equal(1, evt.Previous);
            Assert.Equal(2, evt.Current);
        }

        [Fact]
        public void Constructor_ReferenceType_PropertiesSet()
        {
            var evt = new StateChangeEvent<string>("old", "new");
            Assert.Equal("old", evt.Previous);
            Assert.Equal("new", evt.Current);
        }

        [Fact]
        public void Constructor_NullReferenceType_Allowed()
        {
            var evt = new StateChangeEvent<string>(null, null);
            Assert.Null(evt.Previous);
            Assert.Null(evt.Current);
        }
    }
}
