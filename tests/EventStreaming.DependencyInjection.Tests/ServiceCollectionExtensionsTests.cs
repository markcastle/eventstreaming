using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Inovus.Messaging;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;
using Inovus.Messaging.DependencyInjection;

namespace EventStreaming.DependencyInjection.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ServiceCollectionExtensions"/> DI registration.
    /// </summary>
    public class ServiceCollectionExtensionsTests
    {
        /// <summary>
        /// Ensures AddEventStreaming registers all core services with correct lifetimes.
        /// </summary>
        [Fact]
        public void AddEventStreaming_Registers_All_Core_Services()
        {
            var services = new ServiceCollection();
            services.AddEventStreaming();
            var provider = services.BuildServiceProvider();

            // Singleton sequencers
            var seq1 = provider.GetRequiredService<IEventSequencer>();
            var seq2 = provider.GetRequiredService<IEventSequencer>();
            Assert.Same(seq1, seq2);
            Assert.IsType<EventSequencer>(seq1);

            var streamSeq1 = provider.GetRequiredService<IStreamSequencer>();
            var streamSeq2 = provider.GetRequiredService<IStreamSequencer>();
            Assert.Same(streamSeq1, streamSeq2);
            Assert.IsType<StreamSequencer>(streamSeq1);

            // Transient factories
            var factory1 = provider.GetRequiredService<EventFactory>();
            var factory2 = provider.GetRequiredService<EventFactory>();
            Assert.NotSame(factory1, factory2);
            Assert.IsType<EventFactory>(factory1);

            var streamFactory1 = provider.GetRequiredService<StreamEventFactory>();
            var streamFactory2 = provider.GetRequiredService<StreamEventFactory>();
            Assert.NotSame(streamFactory1, streamFactory2);
            Assert.IsType<StreamEventFactory>(streamFactory1);
        }

        /// <summary>
        /// Ensures AddEventStreaming throws ArgumentNullException when services is null.
        /// </summary>
        [Fact]
        public void AddEventStreaming_NullServices_Throws()
        {
            IServiceCollection services = null;
            Assert.Throws<ArgumentNullException>(() => ServiceCollectionExtensions.AddEventStreaming(services));
        }
    }
}
