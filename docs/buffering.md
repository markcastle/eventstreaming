# Event Buffering in EventStreaming

The `EventStreaming.Buffering` module provides a simple, thread-safe, generic event buffer for use in .NET applications. It is designed for high-throughput, concurrent event ingestion and background processing, supporting both synchronous and asynchronous handlers.

## Key Types

- **ISimpleEventBuffer<T>**: Interface for enqueuing and tracking buffered events.
- **SimpleEventBuffer<T>**: Implementation using `ConcurrentQueue<T>` and a background worker.
- **SimpleEventBufferExtensions**: Static helpers for ergonomic buffer creation.

## Usage Example

### Creating a Buffer (Async Processing)
```csharp
using EventStreaming.Buffering;

using var buffer = SimpleEventBufferExtensions.CreateAsyncBuffer<string>(async msg =>
{
    Console.WriteLine($"[Processed] {msg}");
    await Task.Delay(100); // Simulate work
});

buffer.Enqueue("Event 1");
buffer.Enqueue("Event 2");
```

### Creating a Buffer (Sync Processing)
```csharp
using var buffer = SimpleEventBufferExtensions.CreateSyncBuffer<int>(i =>
{
    Console.WriteLine($"[Processed] {i}");
});

buffer.Enqueue(42);
```

### Custom Event Type Integration
```csharp
public class MyEvent { public int Id { get; set; } public string? Name { get; set; } }

using var buffer = SimpleEventBufferExtensions.CreateAsyncBuffer<MyEvent>(async e =>
{
    Console.WriteLine($"Event {e.Id}: {e.Name}");
    await Task.Delay(20);
});

buffer.Enqueue(new MyEvent { Id = 1, Name = "Test" });
```

## API

- `void Enqueue(T item)`: Add an event to the buffer.
- `int Count`: Number of items currently in the buffer.
- Constructors accept either `Action<T>` or `Func<T, Task>` for processing.
- Implements `IDisposable` for clean shutdown.

## Testing
- 100% unit test coverage for enqueue, process, concurrency, and edge cases.
- Integration tests with custom event types.

## Where to Find
- **Implementation:** `src/EventStreaming.Buffering/`
- **Tests:** `tests/EventStreaming.Buffering.Tests/`
- **Example:** `examples/BufferExample/`

## See Also
- [README.md](../README.md)
- [TASK.md](../TASK.md)
- [PLANNING.md](../PLANNING.md)

---

For advanced scenarios, extend or compose with other EventStreaming modules.
