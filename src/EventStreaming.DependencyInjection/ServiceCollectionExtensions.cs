using System;
using Microsoft.Extensions.DependencyInjection;
using EventStreaming.Events;
using EventStreaming.Factories;
using EventStreaming.Adapters;
using EventStreaming.Primitives;

namespace EventStreaming.DependencyInjection
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

            // Primitives: Register all event primitives for DI (as self for clarity, or as needed for builder/factory integration)
            services.AddTransient<Vector2Event>();
            services.AddTransient<QuaternionEvent>();
            services.AddTransient<FloatEvent>();
            services.AddTransient<IntEvent>();
            services.AddTransient<BoolEvent>();
            services.AddTransient<StringEvent>();
            services.AddTransient<ColorEvent>();
            services.AddTransient<RectEvent>();
            services.AddTransient<KeyPressEvent>();
            services.AddTransient<MouseEvent>();
            services.AddTransient(typeof(CompositeEvent));
            services.AddTransient(typeof(StateChangeEvent<>));
            services.AddTransient(typeof(TimedEvent<>));
            services.AddTransient<CommandEvent>();
            services.AddTransient<CollisionEvent>();
            services.AddTransient(typeof(CustomPayloadEvent<>));
            services.AddTransient<ErrorEvent>();

            // Adapters: static extension methods, no registration needed

            return services;
        }
    }
}
