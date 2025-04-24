using System;
using Xunit;
using Inovus.Messaging;

namespace Inovus.Messaging.Tests.Core
{
    /// <summary>
    /// Unit tests for the <see cref="Guard"/> static class.
    /// </summary>
    public class GuardTests
    {
        /// <summary>
        /// Verifies that NotNull returns the value if not null, or throws otherwise.
        /// </summary>
        [Fact]
        public void NotNull_Returns_Value_If_Not_Null()
        {
            var obj = new object();
            Assert.Same(obj, Guard.NotNull(obj, nameof(obj)));
        }

        /// <summary>
        /// Verifies that NotNull throws ArgumentNullException if the value is null.
        /// </summary>
        [Fact]
        public void NotNull_Throws_If_Null()
        {
            object obj = null;
            Assert.Throws<ArgumentNullException>(() => Guard.NotNull(obj, nameof(obj)));
        }

        /// <summary>
        /// Verifies that NotDefault returns the value if not default, or throws otherwise.
        /// </summary>
        [Fact]
        public void NotDefault_Returns_Value_If_Not_Default()
        {
            int val = 5;
            Assert.Equal(val, Guard.NotDefault(val, nameof(val)));
        }

        /// <summary>
        /// Verifies that NotDefault throws ArgumentException if the value is default.
        /// </summary>
        [Fact]
        public void NotDefault_Throws_If_Default()
        {
            int val = default;
            Assert.Throws<ArgumentException>(() => Guard.NotDefault(val, nameof(val)));
        }
    }
}
