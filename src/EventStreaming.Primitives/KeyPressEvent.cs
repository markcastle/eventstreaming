using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a key press event.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class KeyPressEvent
    {
        /// <summary>
        /// Gets the key code of the key that was pressed.
        /// </summary>
        /// <value>The key code.</value>
        public int KeyCode { get; }
        /// <summary>
        /// Gets the key name that was pressed.
        /// </summary>
        /// <value>The key name.</value>
        public string KeyName { get; }
        /// <summary>
        /// Gets a value indicating whether the key was pressed (true) or released (false).
        /// </summary>
        /// <value>True if pressed; false if released.</value>
        public bool Pressed { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPressEvent"/> class.
        /// </summary>
        /// <param name="keyCode">The key code.</param>
        /// <param name="keyName">The key name.</param>
        /// <param name="pressed">True if pressed; false if released.</param>
        public KeyPressEvent(int keyCode, string keyName, bool pressed)
        {
            KeyCode = keyCode;
            KeyName = keyName ?? string.Empty;
            Pressed = pressed;
        }
    }
}
