using Xunit;
using Inovus.Messaging;

namespace Inovus.Messaging.Tests.Core
{
    public class IEventTests
    {
        [Fact]
        public void Interface_Has_Expected_Properties()
        {
            // Arrange
            var type = typeof(IEvent);

            // Assert
            Assert.NotNull(type.GetProperty("Sequence"));
            Assert.NotNull(type.GetProperty("StreamId"));
            Assert.NotNull(type.GetProperty("Tag"));
        }
    }
}
