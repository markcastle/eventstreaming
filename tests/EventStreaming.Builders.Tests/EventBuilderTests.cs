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

        /// <summary>
        /// Should build a composite event via the fluent API.
        /// </summary>
        [Fact]
        public void Build_CompositeEvent_WithChaining_Succeeds()
        {
            // Arrange
            var builder = EventBuilder.StartWith("start")
                .Add(123)
                .Add(456.78)
                .AddMetadata("source", "unit-test")
                .OnError(e => { /* ignore for test */ });

            // Act
            var composite = builder.Build();

            // Assert
            Assert.NotNull(composite);
            Assert.Equal(3, composite.Events.Count); // start, 123, 456.78
            Assert.Equal("start", composite.Events[0]);
            Assert.Equal(123, composite.Events[1]);
            Assert.Equal(456.78, composite.Events[2]);
            Assert.Equal("unit-test", composite.Metadata["source"]);
        }

        /// <summary>
        /// Should throw if AddMetadata is called with null key.
        /// </summary>
        [Fact]
        public void AddMetadata_NullKey_ThrowsArgumentNullException()
        {
            var builder = EventBuilder.StartWith("evt");
            Assert.Throws<ArgumentNullException>(() => builder.AddMetadata(null, "val"));
        }

        /// <summary>
        /// Should allow OnError handler to be set and invoked.
        /// </summary>
        [Fact]
        public void OnError_HandlerIsCalledOnError()
        {
            var builder = EventBuilder.StartWith("evt");
            bool called = false;
            builder.OnError(_ => called = true);
            // Simulate error
            builder.InvokeError(new Exception());
            Assert.True(called);
        }
    }
}
