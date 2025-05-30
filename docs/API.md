# EventStreaming API Reference

This document provides an overview of the main public types, interfaces, extension methods, and their usage in the EventStreaming library.

---

## Fluent Event Builder API

EventStreaming provides a fluent builder API for all event primitives and composite events. These extension methods enable easy, type-safe construction and chaining of events.

### Example Usage
```csharp
using EventStreaming.Builders;
using EventStreaming.Primitives;

// Build a BoolEvent
var boolEvt = new EventBuilder<BoolEvent>().WithBool(true).Build();

// Build a ColorEvent
var colorEvt = new EventBuilder<ColorEvent>().WithColor(255, 128, 0, 255).Build();

// Build a Vector2Event
var vecEvt = new EventBuilder<Vector2Event>().WithVector2(1.5, -2.5).Build();

// Build a StateChangeEvent
var stateEvt = new EventBuilder<StateChangeEvent<string>>().WithStateChange("old", "new").Build();

// Build a TimedEvent
var timedEvt = new EventBuilder<TimedEvent<int>>().WithTimed(DateTime.UtcNow, 99).Build();

// Build a CustomPayloadEvent
var customEvt = new EventBuilder<CustomPayloadEvent<double>>().WithCustomPayload(3.14).Build();

// Build a CollisionEvent
var collisionEvt = new EventBuilder<CollisionEvent>().WithCollision("A", "B", vecEvt.Payload).Build();
```

#### Composite Event Chaining
```csharp
var composite = EventBuilder.StartWith("start")
    .Add(123)
    .Add(new FloatEvent(456.78f))
    .AddMetadata("source", "unit-test")
    .OnError(e => Console.WriteLine($"Error: {e.Message}"))
    .Build();
```

See `/examples/BasicExample/EventPrimitivesDemo.cs` for more patterns and advanced scenarios.

---

## Namespaces
- `EventStreaming.Events`
- `EventStreaming.Factories`
- `EventStreaming.Adapters`
- `EventStreaming.Core` (if present)

---

## Interfaces
### IEvent
```
public interface IEvent
```
- Immutable event contract. Properties: `long Sequence`, `int StreamId`, `string Tag`.

### IEventSequencer
```
public interface IEventSequencer
```
- Thread-safe, global event sequence generator. Method: `long NextSequence()`

### IStreamSequencer
```
public interface IStreamSequencer
```
- Thread-safe, per-stream sequence generator. Method: `long NextSequence(int streamId)`

---

## Core Classes
### EventBase
```
public abstract class EventBase : IEvent
```
- Base implementation for immutable events. Stores sequence, stream ID, tag.

### EventSequencer
```
public class EventSequencer : IEventSequencer
```
- Lock-free, atomic incrementing global sequencer.

### StreamSequencer
```
public class StreamSequencer : IStreamSequencer
```
- Per-stream sequencing using `ConcurrentDictionary<int, long>`.

---

## Guard Clause Library
### Guard
```
public static class Guard
```
- `NotNull<T>(T value, string paramName)` — Throws if value is null.
- `NotDefault<T>(T value, string paramName)` — Throws if struct is default.

---

## Event Primitives
- `BoolEvent` — Boolean value event
- `IntEvent` — Integer value event
- `FloatEvent` — Floating-point value event
- `StringEvent` — String value event
- `CompositeEvent` — Encapsulates multiple events
- `StateChangeEvent<T>` — Captures a transition from one state to another
- `MouseEvent` — Mouse input (position, button, etc)
- `KeyPressEvent` — Keyboard input (key code, name, pressed/released)
- `TimedEvent<T>` — Value with timestamp
- `QuaternionEvent` — Quaternion (X, Y, Z, W)
- `Vector2Event` — 2D vector
- `ColorEvent` — RGBA color
- `RectEvent` — Rectangle (X, Y, Width, Height)
- `ErrorEvent` — Error message, code, and exception
- `CommandEvent` — Command name/type and optional payload
- `CustomPayloadEvent<T>` — Arbitrary payload event
- `CollisionEvent` — Collision between two entities

See each type's XML documentation for constructor, properties, and usage details.

---

## Domain Events
### Vector3DEvent
```
public sealed class Vector3DEvent : EventBase
```
- Properties: `double X`, `double Y`, `double Z`

### RotationEvent
```
public sealed class RotationEvent : EventBase
```
- Properties: `double Pitch`, `double Yaw`, `double Roll`

---

## Factories
### EventFactory
```
public class EventFactory
```
- Injects `IEventSequencer`. Methods:
  - `CreateVector3DEvent(int streamId, string tag, double x, double y, double z)`
  - `CreateRotationEvent(int streamId, string tag, double pitch, double yaw, double roll)`

### StreamEventFactory
```
public class StreamEventFactory
```
- Injects `IStreamSequencer`. Methods:
  - `CreateVector3DEvent(int streamId, string tag, double x, double y, double z)`
  - `CreateRotationEvent(int streamId, string tag, double pitch, double yaw, double roll)`

---

## Adapters & Extension Methods
### SystemNumericsAdapters
```
public static class SystemNumericsAdapters
```
- `Vector3DEvent ToVector3DEvent(this Vector3 vector, long sequence, int streamId, string tag)`
- `Vector3 ToVector3(this Vector3DEvent evt)`
- `Vector2Event` ⇄ `System.Numerics.Vector2`
- `QuaternionEvent` ⇄ `System.Numerics.Quaternion`

Extension methods are available in `SystemNumericsAdapters`. See `/examples/NumericsIntegrationExample` for usage.

---

## Example Usage
See [usage.md](usage.md) and `/examples` for practical code samples and integration patterns.

---

## Notes
- All public types and methods are fully documented with XML comments in the source code.
- For further details, see the source files and tests.
