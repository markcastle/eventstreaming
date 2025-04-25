using System;
using System.Collections.Generic;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="CompositeEvent"/>.
    /// </summary>
    public class CompositeEventTests
    {
        [Fact]
        public void Constructor_ValidEvents_PropertiesSet()
        {
            var events = new object[] { new IntEvent(1), new StringEvent("A") };
            var evt = new CompositeEvent(events);
            Assert.Equal(2, evt.Events.Count);
            Assert.IsType<IntEvent>(evt.Events[0]);
            Assert.IsType<StringEvent>(evt.Events[1]);
        }

        [Fact]
        public void Constructor_EmptyList_Allowed()
        {
            var evt = new CompositeEvent(new object[0]);
            Assert.NotNull(evt.Events);
            Assert.Empty(evt.Events);
        }

        [Fact]
        public void Constructor_NullList_AllowedAsEmpty()
        {
            var evt = new CompositeEvent(null);
            Assert.NotNull(evt.Events);
            Assert.Empty(evt.Events);
        }
    }
}
