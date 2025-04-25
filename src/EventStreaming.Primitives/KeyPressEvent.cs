using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a key press event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class KeyPressEvent
    {
        /// <summary>Gets the key code (platform-agnostic, e.g., Unicode or scan code).</summary>
        public int KeyCode { get; }
        /// <summary>Gets the key name or character (if available).</summary>
        public string KeyName { get; }
        /// <summary>Gets a value indicating whether the key is pressed (true) or released (false).</summary>
        public bool Pressed { get; }

        /// <summary>
        /// Initializes a new <see cref="KeyPressEvent"/>.
        /// </summary>
        /// <param name="keyCode">The key code (platform-agnostic).</param>
        /// <param name="keyName">The key name or character.</param>
        /// <param name="pressed">Whether the key is pressed (true) or released (false).</param>
        public KeyPressEvent(int keyCode, string keyName, bool pressed)
        {
            KeyCode = keyCode;
            KeyName = keyName ?? string.Empty;
            Pressed = pressed;
        }
    }
}
