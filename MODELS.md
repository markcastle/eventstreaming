# EventStreaming.Abstractions Project

This project contains the core interfaces and contracts for the EventStreaming library.

## Project Structure

```
EventStreaming.Abstractions/
├── EventStreaming.Abstractions.csproj
├── IEvent.cs
├── IEventSequencer.cs
└── IStreamSequencer.cs
```

## Project File

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <PackageId>EventStreaming.Abstractions</PackageId>
    <RootNamespace>EventStreaming</RootNamespace>
    <Version>1.0.0</Version>
    <Authors>Mark Castle</Authors>
    <Description>Abstractions and interfaces for the EventStreaming library, providing contracts for event-based architectures.</Description>
    <PackageTags>events;streaming;sequencing;realtime;abstractions</PackageTags>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <RepositoryUrl>https://github.com/Mark Castle/eventstreaming</RepositoryUrl>
  </PropertyGroup>

</Project>
```

## Core Interfaces

### IEvent Interface

The `IEvent` interface defines the core properties that all events must implement:

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.

using System;

namespace EventStreaming
{
    /// <summary>
    /// Defines the core properties and behavior for all events in the event streaming system.
    /// Events can be sequentially ordered and routed to specific streams using StreamId and Tag.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Unique identifier for the event.
        /// </summary>
        Guid Id { get; }
        
        /// <summary>
        /// Sequential number of this event in the stream. Used for ordering events.
        /// </summary>
        long SequenceNumber { get; set; }
        
        /// <summary>
        /// Stream identifier for routing events to specific streams.
        /// Works like a VLAN ID in networking, enabling logical separation of event streams.
        /// </summary>
        int StreamId { get; }
        
        /// <summary>
        /// Optional tag for sub-categorizing events within a stream.
        /// Works like an MPLS label in networking, providing additional routing information.
        /// </summary>
        int Tag { get; }
        
        /// <summary>
        /// Timestamp when the event was created.
        /// </summary>
        DateTimeOffset Timestamp { get; }
        
        /// <summary>
        /// The type of event, used for identification and potentially deserialization.
        /// </summary>
        string EventType { get; }
    }
}
```

### IEventSequencer Interface

The `IEventSequencer` interface defines how sequential numbers are assigned to events:

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.

using System;

namespace EventStreaming
{
    /// <summary>
    /// Defines a service responsible for assigning sequential numbers to events.
    /// Uses a global counter for all events regardless of their stream.
    /// </summary>
    public interface IEventSequencer
    {
        /// <summary>
        /// Assigns the next sequence number to an event.
        /// Implementation must be thread-safe as this will likely be called from multiple threads.
        /// </summary>
        /// <param name="event">The event to which a sequence number should be assigned.</param>
        void AssignSequenceNumber(IEvent @event);
        
        /// <summary>
        /// Gets the current highest sequence number that has been assigned.
        /// </summary>
        long CurrentSequence { get; }
    }
}
```

### IStreamSequencer Interface

The `IStreamSequencer` interface defines how sequential numbers are assigned per stream:

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.

using System;

namespace EventStreaming
{
    /// <summary>
    /// Defines a service responsible for assigning sequential numbers to events per stream.
    /// Maintains separate counters for each stream ID, allowing independent sequencing.
    /// </summary>
    public interface IStreamSequencer
    {
        /// <summary>
        /// Assigns the next sequence number to an event within its stream.
        /// Each stream has its own independent counter.
        /// Implementation must be thread-safe as this will likely be called from multiple threads.
        /// </summary>
        /// <param name="event">The event to which a stream-specific sequence number should be assigned.</param>
        void AssignSequenceNumber(IEvent @event);
        
        /// <summary>
        /// Gets the current sequence number for a specific stream.
        /// </summary>
        /// <param name="streamId">The stream identifier</param>
        /// <returns>The current sequence number for the stream, or 0 if the stream doesn't exist.</returns>
        long GetCurrentSequence(int streamId);
    }
}
```