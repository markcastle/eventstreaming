using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a color event with RGBA byte components.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class ColorEvent
    {
        /// <summary>
        /// Gets the red component (0-255).
        /// </summary>
        /// <value>The red component value (0-255).</value>
        public byte R { get; }

        /// <summary>
        /// Gets the green component (0-255).
        /// </summary>
        /// <value>The green component value (0-255).</value>
        public byte G { get; }

        /// <summary>
        /// Gets the blue component (0-255).
        /// </summary>
        /// <value>The blue component value (0-255).</value>
        public byte B { get; }

        /// <summary>
        /// Gets the alpha component (0-255).
        /// </summary>
        /// <value>The alpha component value (0-255).</value>
        public byte A { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEvent"/> class.
        /// </summary>
        /// <param name="r">Red (0-255).</param>
        /// <param name="g">Green (0-255).</param>
        /// <param name="b">Blue (0-255).</param>
        /// <param name="a">Alpha (0-255).</param>
        public ColorEvent(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
