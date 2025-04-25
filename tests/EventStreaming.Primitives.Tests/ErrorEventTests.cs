using System;
using Xunit;
using EventStreaming.Primitives;

namespace EventStreaming.Primitives.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ErrorEvent"/>.
    /// </summary>
    public class ErrorEventTests
    {
        [Fact]
        public void Constructor_ValidValues_PropertiesSet()
        {
            var ex = new System.Exception("fail");
            var evt = new ErrorEvent("msg", 42, ex);
            Assert.Equal("msg", evt.Message);
            Assert.Equal(42, evt.Code);
            Assert.Equal(ex, evt.Exception);
        }

        [Fact]
        public void Constructor_NullCodeAndException_Allowed()
        {
            var evt = new ErrorEvent("err");
            Assert.Equal("err", evt.Message);
            Assert.Null(evt.Code);
            Assert.Null(evt.Exception);
        }

        [Fact]
        public void Constructor_NullMessage_SetsToEmpty()
        {
            var evt = new ErrorEvent(null);
            Assert.Equal(string.Empty, evt.Message);
        }
    }
}
