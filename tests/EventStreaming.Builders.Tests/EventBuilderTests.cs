using System;
using Xunit;
using EventStreaming.Builders;

namespace EventStreaming.Builders.Tests
{
    /// <summary>
    /// Unit tests for the EventBuilder fluent API.
    /// </summary>
    public class EventBuilderTests
    {
        /// <summary>
        /// Should build a simple event with required properties.
        /// </summary>
        [Fact]
        public void Build_SimpleEvent_Succeeds()
        {
            // Arrange
            var builder = new EventBuilder<string>();
            // Act
            var evt = builder.WithPayload("test").Build();
            // Assert
            Assert.NotNull(evt);
            Assert.Equal("test", evt.Payload);
        }

        /// <summary>
        /// Should handle edge case: null payload.
        /// </summary>
        [Fact]
        public void Build_NullPayload_ThrowsArgumentNullException()
        {
            // Arrange
            var builder = new EventBuilder<string>();
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.WithPayload(null).Build());
        }

        /// <summary>
        /// Should fail if Build is called without setting required properties.
        /// </summary>
        [Fact]
        public void Build_WithoutPayload_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new EventBuilder<string>();
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }
    }
}
