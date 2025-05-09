using Xunit;
using EventStreaming.Abstractions;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="IEvent"/> interface.
    /// </summary>
    public class IEventTests
    {
        /// <summary>
        /// Verifies that <see cref="IEvent"/> defines the expected properties.
        /// </summary>
        [Fact]
        public void Interface_Has_Expected_Properties()
        {
            // Arrange
            var type = typeof(EventStreaming.Abstractions.IEvent);

            // Assert
            Assert.NotNull(type.GetProperty("Sequence"));
            Assert.NotNull(type.GetProperty("StreamId"));
            Assert.NotNull(type.GetProperty("Tag"));
        }
    }
}
