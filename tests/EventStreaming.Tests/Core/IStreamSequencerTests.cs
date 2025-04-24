using Xunit;
using Inovus.Messaging;

namespace Inovus.Messaging.Tests.Core
{
    public class IStreamSequencerTests
    {
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
