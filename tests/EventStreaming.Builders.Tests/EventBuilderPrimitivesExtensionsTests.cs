using System;
using EventStreaming.Builders;
using EventStreaming.Primitives;
using Xunit;

namespace EventStreaming.Builders.Tests
{
    /// <summary>
    /// Unit tests for EventBuilderPrimitivesExtensions covering all supported event primitives.
    /// </summary>
    public class EventBuilderPrimitivesExtensionsTests
    {
        [Fact]
        public void WithBool_BuildsBoolEvent()
        {
            var evt = new EventBuilder<BoolEvent>().WithBool(true).Build();
            Assert.True(evt.Payload.Value);
        }

        [Fact]
        public void WithInt_BuildsIntEvent()
        {
            var evt = new EventBuilder<IntEvent>().WithInt(42).Build();
            Assert.Equal(42, evt.Payload.Value);
        }

        [Fact]
        public void WithFloat_BuildsFloatEvent()
        {
            var evt = new EventBuilder<FloatEvent>().WithFloat(3.14f).Build();
            Assert.Equal(3.14f, evt.Payload.Value);
        }

        [Fact]
        public void WithString_BuildsStringEvent()
        {
            var evt = new EventBuilder<StringEvent>().WithString("hello").Build();
            Assert.Equal("hello", evt.Payload.Value);
        }

        [Fact]
        public void WithColor_BuildsColorEvent()
        {
            var evt = new EventBuilder<ColorEvent>().WithColor(10, 20, 30, 40).Build();
            Assert.Equal(10, evt.Payload.R);
            Assert.Equal(20, evt.Payload.G);
            Assert.Equal(30, evt.Payload.B);
            Assert.Equal(40, evt.Payload.A);
        }

        [Fact]
        public void WithVector2_BuildsVector2Event()
        {
            var evt = new EventBuilder<Vector2Event>().WithVector2(1.1, 2.2).Build();
            Assert.Equal(1.1, evt.Payload.X);
            Assert.Equal(2.2, evt.Payload.Y);
        }

        [Fact]
        public void WithQuaternion_BuildsQuaternionEvent()
        {
            var evt = new EventBuilder<QuaternionEvent>().WithQuaternion(1, 2, 3, 4).Build();
            Assert.Equal(1, evt.Payload.X);
            Assert.Equal(2, evt.Payload.Y);
            Assert.Equal(3, evt.Payload.Z);
            Assert.Equal(4, evt.Payload.W);
        }

        [Fact]
        public void WithRect_BuildsRectEvent()
        {
            var evt = new EventBuilder<RectEvent>().WithRect(1, 2, 3, 4).Build();
            Assert.Equal(1, evt.Payload.X);
            Assert.Equal(2, evt.Payload.Y);
            Assert.Equal(3, evt.Payload.Width);
            Assert.Equal(4, evt.Payload.Height);
        }

        [Fact]
        public void WithKeyPress_BuildsKeyPressEvent()
        {
            var evt = new EventBuilder<KeyPressEvent>().WithKeyPress(13, "Enter", true).Build();
            Assert.Equal(13, evt.Payload.KeyCode);
            Assert.Equal("Enter", evt.Payload.KeyName);
            Assert.True(evt.Payload.Pressed);
        }

        [Fact]
        public void WithMouse_BuildsMouseEvent()
        {
            var evt = new EventBuilder<MouseEvent>().WithMouse(100, 200, 1, false).Build();
            Assert.Equal(100, evt.Payload.X);
            Assert.Equal(200, evt.Payload.Y);
            Assert.Equal(1, evt.Payload.Button);
            Assert.False(evt.Payload.Pressed);
        }

        [Fact]
        public void WithStateChange_BuildsStateChangeEvent()
        {
            var evt = new EventBuilder<StateChangeEvent<int>>().WithStateChange(1, 2).Build();
            Assert.Equal(1, evt.Payload.Previous);
            Assert.Equal(2, evt.Payload.Current);
        }

        [Fact]
        public void WithTimed_BuildsTimedEvent()
        {
            var now = DateTime.UtcNow;
            var evt = new EventBuilder<TimedEvent<string>>().WithTimed(now, "payload").Build();
            Assert.Equal(now, evt.Payload.Timestamp);
            Assert.Equal("payload", evt.Payload.Value);
        }

        [Fact]
        public void WithCommand_BuildsCommandEvent()
        {
            var evt = new EventBuilder<CommandEvent>().WithCommand("run", 123).Build();
            Assert.Equal("run", evt.Payload.Command);
            Assert.Equal(123, evt.Payload.Payload);
        }

        [Fact]
        public void WithCustomPayload_BuildsCustomPayloadEvent()
        {
            var evt = new EventBuilder<CustomPayloadEvent<double>>().WithCustomPayload(5.5).Build();
            Assert.Equal(5.5, evt.Payload.Payload);
        }

        [Fact]
        public void WithCollision_BuildsCollisionEvent()
        {
            var a = new object();
            var b = new object();
            var point = new object();
            var evt = new EventBuilder<CollisionEvent>().WithCollision(a, b, point).Build();
            Assert.Equal(a, evt.Payload.EntityA);
            Assert.Equal(b, evt.Payload.EntityB);
            Assert.Equal(point, evt.Payload.Point);
        }

        [Fact]
        public void WithString_NullValue_Throws()
        {
            var builder = new EventBuilder<StringEvent>();
            Assert.Throws<ArgumentNullException>(() => builder.WithString(null));
        }
    }
}
