using System;
using Microsoft.Extensions.DependencyInjection;
using EventStreaming.Abstractions;

namespace EventStreaming.InputBuffer
{
    /// <summary>
    /// Provides extension methods for registering input buffers in a dependency injection container.
    /// </summary>
    public static class InputBufferServiceCollectionExtensions
    {
        /// <summary>
        /// Registers a singleton <see cref="IInputBuffer{T}"/> and its implementation <see cref="InputBuffer{T}"/> in the service collection.
        /// Optionally configures the buffer by registering handlers/middleware.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="configure">An optional configuration action for the buffer (e.g., to register handlers).</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInputBuffer<T>(
            this IServiceCollection services,
            Action<IInputBuffer<T>>? configure = null)
        {
            services.AddSingleton<IInputBuffer<T>, InputBuffer<T>>();
            if (configure != null)
            {
                services.PostConfigure<IInputBuffer<T>>(configure);
            }
            return services;
        }
    }
}
