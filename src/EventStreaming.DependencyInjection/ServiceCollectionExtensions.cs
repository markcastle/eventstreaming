using System;
using Microsoft.Extensions.DependencyInjection;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;
using Inovus.Messaging.Adapters;

namespace Inovus.Messaging.DependencyInjection
{
    /// <summary>
    /// Extension methods for registering EventStreaming services with Microsoft.Extensions.DependencyInjection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all core EventStreaming services (sequencers, factories, adapters) for dependency injection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> instance so that multiple calls can be chained.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="services"/> is null.</exception>
        public static IServiceCollection AddEventStreaming(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Sequencers
            services.AddSingleton<IEventSequencer, EventSequencer>();
            services.AddSingleton<IStreamSequencer, StreamSequencer>();

            // Factories
            services.AddTransient<EventFactory>();
            services.AddTransient<StreamEventFactory>();

            // Adapters: static extension methods, no registration needed

            return services;
        }
    }
}
