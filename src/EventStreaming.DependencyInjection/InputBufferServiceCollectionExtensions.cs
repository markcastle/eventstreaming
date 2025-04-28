using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EventStreaming.Abstractions;
using EventStreaming.Buffering;

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
            var buffer = new InputBuffer<T>();
            configure?.Invoke(buffer);
            services.AddSingleton<IInputBuffer<T>>(buffer);
            return services;
        }

        /// <summary>
        /// Registers a singleton <see cref="IInputBuffer{T}"/> implemented by <see cref="BatchingInputBuffer{T}"/> in the service collection.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="batchSize">The size of each batch.</param>
        /// <param name="configure">An optional configuration action for the buffer (e.g., to register batch handlers).</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddBatchingInputBuffer<T>(
            this IServiceCollection services,
            int batchSize,
            Action<IInputBuffer<IReadOnlyList<T>>>? configure = null)
        {
            var buffer = new BatchingInputBuffer<T>(batchSize);
            configure?.Invoke(buffer);
            services.AddSingleton<IInputBuffer<IReadOnlyList<T>>>(buffer);
            return services;
        }

        /// <summary>
        /// Registers a singleton <see cref="IInputBuffer{T}"/> implemented by <see cref="FilteringInputBuffer{T}"/> in the service collection.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="filter">Optional filter predicate.</param>
        /// <param name="comparer">Optional equality comparer for deduplication.</param>
        /// <param name="configure">An optional configuration action for the buffer (e.g., to register handlers).</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddFilteringInputBuffer<T>(
            this IServiceCollection services,
            Func<T, bool>? filter = null,
            IEqualityComparer<T>? comparer = null,
            Action<IInputBuffer<T>>? configure = null)
        {
            var buffer = new FilteringInputBuffer<T>(filter, comparer);
            configure?.Invoke(buffer);
            services.AddSingleton<IInputBuffer<T>>(buffer);
            return services;
        }

        /// <summary>
        /// Registers a singleton <see cref="SimpleEventBuffer{T}"/> in the service collection.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="asyncProcessor">The async delegate to process items.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddSimpleEventBuffer<T>(
            this IServiceCollection services,
            Func<T, Task> asyncProcessor)
        {
            services.AddSingleton(new Buffering.SimpleEventBuffer<T>(asyncProcessor));
            return services;
        }

        /// <summary>
        /// Registers a singleton <see cref="SimpleEventBuffer{T}"/> in the service collection.
        /// </summary>
        /// <typeparam name="T">The event type.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="syncProcessor">The sync delegate to process items.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddSimpleEventBuffer<T>(
            this IServiceCollection services,
            Action<T> syncProcessor)
        {
            services.AddSingleton(new Buffering.SimpleEventBuffer<T>(syncProcessor));
            return services;
        }
    }
}
