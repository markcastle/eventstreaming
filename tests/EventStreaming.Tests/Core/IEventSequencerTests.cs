using Xunit;
using Inovus.Messaging;

namespace Inovus.Messaging.Tests.Core
{
    public class IEventSequencerTests
    {
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
