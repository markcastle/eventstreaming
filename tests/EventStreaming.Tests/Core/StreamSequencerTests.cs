using Xunit;
using EventStreaming.Abstractions;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="IStreamSequencer"/> interface.
    /// </summary>
    public class StreamSequencerTests
    {
        /// <summary>
        /// Verifies that <see cref="IStreamSequencer.NextSequence(int)"/> returns incrementing values per stream.
        /// </summary>
        [Fact]
        public void NextSequence_Returns_Incrementing_Values_Per_Stream()
        {
            var sequencer = new StreamSequencer();
            Assert.Equal(1, sequencer.NextSequence(1));
            Assert.Equal(2, sequencer.NextSequence(1));
            Assert.Equal(1, sequencer.NextSequence(2));
            Assert.Equal(3, sequencer.NextSequence(1));
            Assert.Equal(2, sequencer.NextSequence(2));
        }
    }
}
