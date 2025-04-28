using Microsoft.Extensions.DependencyInjection;
using EventStreaming.Abstractions;

namespace EventStreaming.SystemTextJson
{
    /// <summary>
    /// Extension methods for registering the SystemTextJsonEventSerializer with dependency injection.
    /// </summary>
    public static class SystemTextJsonEventSerializerServiceCollectionExtensions
    {
        /// <summary>
        /// Registers <see cref="SystemTextJsonEventSerializer"/> as the default <see cref="IEventSerializer"/>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddSystemTextJsonEventSerializer(this IServiceCollection services)
        {
            // Reason: Allows user to select System.Text.Json as the event serializer via DI.
            services.AddSingleton<IEventSerializer, SystemTextJsonEventSerializer>();
            return services;
        }
    }
}
