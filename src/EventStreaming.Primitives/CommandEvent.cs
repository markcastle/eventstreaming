using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents a command event, typically for signaling actions.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class CommandEvent
    {
        /// <summary>
        /// Gets the command name or type.
        /// </summary>
        /// <value>The command name or type.</value>
        public string Command { get; }
        /// <summary>
        /// Gets an optional payload for the command.
        /// </summary>
        /// <value>The optional payload.</value>
        public object Payload { get; }

        /// <summary>
        /// Initializes a new <see cref="CommandEvent"/>.
        /// </summary>
        /// <param name="command">The command name or type.</param>
        /// <param name="payload">The optional payload.</param>
        public CommandEvent(string command, object payload = null)
        {
            Command = command ?? string.Empty;
            Payload = payload;
        }
    }
}
