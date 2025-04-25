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
        /// Gets the key that was pressed.
        /// </summary>
        /// <value>The key value.</value>
        public string Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPressEvent"/> class.
        /// </summary>
        /// <param name="key">The key that was pressed.</param>
        public KeyPressEvent(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }
    }
}
