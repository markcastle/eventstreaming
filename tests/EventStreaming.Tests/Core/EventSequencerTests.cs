using Xunit;
using EventStreaming;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="EventSequencer"/> class.
    /// </summary>
    public class EventSequencerTests
    {
        /// <summary>
        /// Verifies that <see cref="EventSequencer.NextSequence"/> returns incrementing values starting from 1 (default).
        /// </summary>
        [Fact]
        public void NextSequence_Returns_Incrementing_Values()
        {
            var sequencer = new EventSequencer();
            Assert.Equal(1, sequencer.NextSequence());
            Assert.Equal(2, sequencer.NextSequence());
            Assert.Equal(3, sequencer.NextSequence());
        }

        /// <summary>
        /// Verifies that <see cref="EventSequencer"/> can start from a custom initial value.
        /// </summary>
        [Fact]
        public void Can_Start_From_Custom_Initial_Value()
        {
            var sequencer = new EventSequencer(100);
            Assert.Equal(100, sequencer.NextSequence());
            Assert.Equal(101, sequencer.NextSequence());
        }
    }
}
