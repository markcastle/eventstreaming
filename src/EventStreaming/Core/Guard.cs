using System;

namespace EventStreaming
{
    /// <summary>
    /// Provides static guard clauses for parameter validation.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the specified reference is null.
        /// </summary>
        /// <typeparam name="T">The reference type.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>The validated value.</returns>
        public static T NotNull<T>(T value, string paramName) where T : class
        {
            if (value is null)
                throw new ArgumentNullException(paramName);
            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the specified struct is its default value.
        /// </summary>
        /// <typeparam name="T">The struct type.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>The validated value.</returns>
        public static T NotDefault<T>(T value, string paramName) where T : struct
        {
            if (value.Equals(default(T)))
                throw new ArgumentException($"Parameter '{paramName}' must not be the default value.", paramName);
            return value;
        }
    }
}
