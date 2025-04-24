# EventStreaming Library

A lightweight, fully-tested event–stream sequencing library for .NET Standard 2.1+.

- **Namespace root:** `Inovus.Messaging`
- **Purpose:** Embeddable in any .NET app (desktop, mobile, game, server, IoT) with no forced transport/serializer/DI container.
- **Principles:** SOLID, YAGNI, KISS, full code coverage.

## Getting Started

See `PLANNING.md` and `TASK.md` for the development roadmap.

## Directory Structure
- `src/` – Core library source
- `tests/` – Unit/integration tests
- `examples/` – Usage examples
- `docs/` – Documentation

## Abstractions
- `IEvent` interface (immutable, with sequence, stream, tag)
- `IEventSequencer` (thread-safe, global)
- `IStreamSequencer` (per-stream)

## Core Implementation
- `EventBase` (abstract, immutable, stores sequence, streamId, tag)
- `EventSequencer` (lock-free, thread-safe, global, starts at 1)
- `StreamSequencer` (thread-safe, per-stream, starts at 1)

## Utilities
- `Guard` static class for parameter validation (`NotNull`, `NotDefault`)

## Concurrency & Robustness
- Sequencers are thread-safe and tested under heavy parallel load
- High-concurrency stress tests ensure reliability in real-world scenarios

## Testing
- 100% code coverage target
- Tests live in `/tests/EventStreaming.Tests/` mirroring the main app structure

## Test Status
- All core abstractions and implementations are fully covered by unit tests
- Tests pass on .NET 7.0 (xUnit)

## License
MIT (see LICENCE file)
