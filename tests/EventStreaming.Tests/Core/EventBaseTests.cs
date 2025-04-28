using Xunit;
using EventStreaming.Abstractions;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="EventBase"/> abstract class.
    /// </summary>
    public class EventBaseTests
    {
        /// <summary>
        /// A minimal concrete implementation of <see cref="EventBase"/> for testing.
        /// </summary>
        private class TestEvent : EventBase
        {
            public TestEvent(long seq, int stream, string tag) : base(seq, stream, tag) { }
        }

        /// <summary>
        /// Verifies that <see cref="EventBase"/> correctly stores property values.
        /// </summary>
        [Fact]
        public void Properties_Are_Immutable_And_Set()
        {
            var evt = new TestEvent(42, 7, "test");
            Assert.Equal(42, evt.Sequence);
            Assert.Equal(7, evt.StreamId);
            Assert.Equal("test", evt.Tag);
        }
    }
}
