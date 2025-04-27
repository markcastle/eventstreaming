# EventStreaming User Guide

## Overview
EventStreaming is a robust, embeddable .NET library for event sequencing, streaming, and domain event modeling. It features:
- Thread-safe, lock-free global and per-stream sequencing
- Immutable domain events
- Guard-clause validation
- Factory pattern for event creation
- Seamless integration with `System.Numerics.Vector3`
- Comprehensive tests and adapters

## Installation
1. **Add the library:**
   - Reference the compiled NuGet package (coming soon), or
   - Add the project reference to your solution:
     ```xml
     <ProjectReference Include="../src/EventStreaming/EventStreaming.csproj" />
     ```
2. **.NET Standard 2.1+** is required for the core library. Examples and tests target .NET 7.0.

## Getting Started
### 1. Sequencing Events
```csharp
var sequencer = new EventSequencer();
long nextSeq = sequencer.NextSequence();
```

### 2. Creating Domain Events
```csharp
var factory = new EventFactory(sequencer);
var evt = factory.CreateVector3DEvent(1, "move", 1.0, 2.0, 3.0);
```

### 3. Fluent Event Builder Usage

EventStreaming provides a fluent builder API for composing events in a readable and expressive way.

```csharp
// BoolEvent
var boolEvt = new EventBuilder<BoolEvent>().WithBool(true).Build();

// IntEvent
var intEvt = new EventBuilder<IntEvent>().WithInt(42).Build();

// ColorEvent
var colorEvt = new EventBuilder<ColorEvent>().WithColor(255, 128, 0, 255).Build();

// Vector2Event
var vecEvt = new EventBuilder<Vector2Event>().WithVector2(1.5, -2.5).Build();

// StateChangeEvent
var stateEvt = new EventBuilder<StateChangeEvent<string>>().WithStateChange("old", "new").Build();

// TimedEvent
var timedEvt = new EventBuilder<TimedEvent<int>>().WithTimed(DateTime.UtcNow, 99).Build();

// CustomPayloadEvent
var customEvt = new EventBuilder<CustomPayloadEvent<double>>().WithCustomPayload(3.14).Build();

// CollisionEvent
var collisionEvt = new EventBuilder<CollisionEvent>().WithCollision("Player", "Wall", vecEvt.Payload).Build();
```

You can also chain and compose composite events:

```csharp
var composite = EventBuilder.StartWith("start")
    .Add(123)
    .Add(new FloatEvent(456.78f))
    .AddMetadata("source", "unit-test")
    .OnError(e => Console.WriteLine($"Error: {e.Message}"))
    .Build();
```

See `/examples/BasicExample/EventPrimitivesDemo.cs` for more usage patterns.

### 4. Per-Stream Sequencing
```csharp
var streamSequencer = new StreamSequencer();
var streamFactory = new StreamEventFactory(streamSequencer);
var streamEvt = streamFactory.CreateVector3DEvent(2, "move", 4.0, 5.0, 6.0);
```

### 5. Adapters for System.Numerics.Vector3
```csharp
using System.Numerics;
using EventStreaming.Adapters;

Vector3 pos = new Vector3(1.1f, 2.2f, 3.3f);
var evt = pos.ToVector3DEvent(42, 7, "tag");
Vector3 roundTrip = evt.ToVector3();
```

## Serializer Support

EventStreaming lets you choose your serialization backend via the `IEventSerializer` abstraction:

- **System.Text.Json** (recommended for .NET Core/Standard):
  - Register with DI: `services.AddSystemTextJsonEventSerializer()`
  - Or use manually: `new SystemTextJsonEventSerializer()`
- **Newtonsoft.Json (JsonNet)** (recommended for Unity/legacy):
  - Use manually: `new JsonNetEventSerializer()`
  - No DI helper provided (manual registration only)

See [docs/serialization.md](serialization.md) for full details, usage, and serializer comparison.

## Example Projects
- **BasicExample:** Single stream event sequencing
- **MultiStreamExample:** Concurrent, per-stream sequencing
- **NumericsIntegrationExample:** Unity-style integration with `Vector3`

See `/examples` for runnable code.

## Best Practices
- Use factories to ensure correct sequencing and immutability.
- Validate parameters with `Guard` methods.
- Use extension methods for seamless type conversion.

## Further Reading
- [API Reference](API.md)
- [Changelog](../CHANGELOG.md)
- [Examples](../examples/)
- [Project Tasks](../TASK.md)

---

For advanced usage, mutation testing, and future roadmap, see the main README and project documentation.
