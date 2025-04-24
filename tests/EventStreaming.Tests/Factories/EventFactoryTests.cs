using Xunit;
using Inovus.Messaging.Factories;
using Inovus.Messaging.Events;
using Moq;

namespace Inovus.Messaging.Tests.Factories
{
    /// <summary>
    /// Unit tests for the <see cref="EventFactory"/> class.
    /// </summary>
    public class EventFactoryTests
    {
        /// <summary>
        /// Verifies that <see cref="EventFactory"/> creates <see cref="Vector3DEvent"/> with correct values and sequence.
        /// </summary>
        [Fact]
        public void CreateVector3DEvent_Sets_All_Properties()
        {
            var mockSequencer = new Mock<IEventSequencer>();
            mockSequencer.Setup(s => s.NextSequence()).Returns(123);
            var factory = new EventFactory(mockSequencer.Object);

            var evt = factory.CreateVector3DEvent(7, "vector", 1.1, 2.2, 3.3);

            Assert.Equal(123, evt.Sequence);
            Assert.Equal(7, evt.StreamId);
            Assert.Equal("vector", evt.Tag);
            Assert.Equal(1.1, evt.X);
            Assert.Equal(2.2, evt.Y);
            Assert.Equal(3.3, evt.Z);
        }

        /// <summary>
        /// Verifies that <see cref="EventFactory"/> creates <see cref="RotationEvent"/> with correct values and sequence.
        /// </summary>
        [Fact]
        public void CreateRotationEvent_Sets_All_Properties()
        {
            var mockSequencer = new Mock<IEventSequencer>();
            mockSequencer.Setup(s => s.NextSequence()).Returns(456);
            var factory = new EventFactory(mockSequencer.Object);

            var evt = factory.CreateRotationEvent(8, "rot", 10.5, 20.5, 30.5);

            Assert.Equal(456, evt.Sequence);
            Assert.Equal(8, evt.StreamId);
            Assert.Equal("rot", evt.Tag);
            Assert.Equal(10.5, evt.Pitch);
            Assert.Equal(20.5, evt.Yaw);
            Assert.Equal(30.5, evt.Roll);
        }

        /// <summary>
        /// Verifies that the constructor throws if sequencer is null.
        /// </summary>
        [Fact]
        public void Constructor_Throws_If_Sequencer_Null()
        {
            Assert.Throws<System.ArgumentNullException>(() => new EventFactory(null));
        }
    }
}
