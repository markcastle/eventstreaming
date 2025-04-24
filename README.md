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

## Testing
- 100% code coverage target
- Tests live in `/tests/EventStreaming.Tests/` mirroring the main app structure

## License
MIT (see LICENCE file)
