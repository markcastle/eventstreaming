using Xunit;
using EventStreaming;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="IEventSequencer"/> interface.
    /// </summary>
    public class IEventSequencerTests
    {
        /// <summary>
        /// Verifies that <see cref="IEventSequencer"/> defines the expected method signature for NextSequence.
        /// </summary>
        [Fact]
        public void Interface_Has_Expected_Method()
        {
            var type = typeof(IEventSequencer);
            var method = type.GetMethod("NextSequence");
            Assert.NotNull(method);
            Assert.Equal(typeof(long), method.ReturnType);
        }
    }
}
