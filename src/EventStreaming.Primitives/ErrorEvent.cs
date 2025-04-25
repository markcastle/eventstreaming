using System;

namespace EventStreaming.Primitives
{
    /// <summary>
    /// Represents an error event, holding error details and optional exception.
    /// Immutable and suitable for use in event streaming scenarios.
    /// </summary>
    public sealed class ErrorEvent
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string Message { get; }
        /// <summary>
        /// Gets the error code (optional).
        /// </summary>
        /// <value>The error code, or null if not set.</value>
        public int? Code { get; }
        /// <summary>
        /// Gets the exception (optional).
        /// </summary>
        /// <value>The exception associated with the error, or null if not set.</value>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new <see cref="ErrorEvent"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="code">The error code (optional).</param>
        /// <param name="exception">The exception (optional).</param>
        public ErrorEvent(string message, int? code = null, Exception exception = null)
        {
            Message = message ?? string.Empty;
            Code = code;
            Exception = exception;
        }
    }
}
