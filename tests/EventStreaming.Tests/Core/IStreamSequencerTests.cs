using Xunit;
using EventStreaming.Abstractions;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="IStreamSequencer"/> interface.
    /// </summary>
    public class IStreamSequencerTests
    {
        /// <summary>
        /// Verifies that <see cref="IStreamSequencer"/> defines the expected method signature for NextSequence.
        /// </summary>
        [Fact]
        public void Interface_Has_Expected_Method()
        {
            var type = typeof(IStreamSequencer);
            var method = type.GetMethod("NextSequence");
            Assert.NotNull(method);
            Assert.Equal(typeof(long), method.ReturnType);
            Assert.Single(method.GetParameters());
            Assert.Equal(typeof(int), method.GetParameters()[0].ParameterType);
        }
    }
}
