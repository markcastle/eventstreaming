# 🎉 EventStreaming

[![Build Status](https://github.com/markcastle/eventstreaming/actions/workflows/build.yml/badge.svg)](https://github.com/markcastle/eventstreaming/actions)
[![Coverage Status](https://img.shields.io/badge/coverage-100%25-brightgreen)](https://coveralls.io/github/markcastle/eventstreaming)
[![NuGet](https://img.shields.io/nuget/v/EventStreaming.svg)](https://www.nuget.org/packages/EventStreaming)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](./LICENCE)
[![.NET Standard 2.1](https://img.shields.io/badge/.NET-Standard%202.1-blue)](https://dotnet.microsoft.com/)

EventStreaming is a robust, high-performance .NET library for event sequencing, streaming, and domain event modeling. Built for reliability, concurrency, and extensibility—perfect for games, simulations, distributed systems, and more!

## What is EventStreaming for?

EventStreaming is designed to provide a flexible, lock-free, and highly concurrent event sequencing and streaming foundation for .NET applications. It is used for:

- 🎮 **Game development:** Deterministic event replay, rollback, and simulation in multiplayer and real-time games (Unity, Godot, custom engines)
- 🧪 **Simulations:** Physics, robotics, and digital twin systems requiring precise event order and replay
- 🌐 **Distributed systems:** Event sourcing, CQRS, and distributed messaging where event order and atomicity matter
- 📡 **IoT and telemetry:** High-throughput event ingestion and processing
- 📊 **Data pipelines:** Stream processing, analytics, and time-series event modeling
- 🧩 **Testing:** Generating reproducible event streams for scenario-based and property-based testing
- 🛡️ **Any scenario** where you need robust, thread-safe, and immutable event handling with support for custom domain events and serialization

**⚡ Coupling with Queuing/Buffering Systems:**

EventStreaming can be integrated with queuing or buffering systems (such as message queues, ring buffers, or concurrent queues) to enable advanced event handling and delivery patterns:

- 🌀 **Buffering:** Use a concurrent queue or ring buffer to temporarily store events before processing. This is ideal for bursty workloads or when consumer processing is decoupled from event production.
- 📬 **Queuing:** Couple EventStreaming with systems like RabbitMQ, Azure Service Bus, or in-memory queues to distribute events across processes or services, enabling scalable and reliable event-driven architectures.
- ⏪ **Replay/Gap Detection:** Buffer events for replay, out-of-order delivery, or gap detection—useful for distributed or networked systems where events may arrive late or out of sequence.
- 🚦 **Backpressure:** Integrate with buffering mechanisms to apply backpressure and control flow, ensuring that slow consumers do not overwhelm the system.

By combining EventStreaming’s sequencing and immutability with robust queuing/buffering, you gain:
- ✅ Reliable, ordered delivery of events
- 🔄 Decoupled producers and consumers
- 📦 Support for retries, batching, and flow control
- 🚀 Enhanced scalability and resilience for real-time and distributed applications

EventStreaming is used by developers who need:
- 🔒 Lock-free, thread-safe sequencing for global or per-stream events
- 🧊 Immutability and safety for domain events
- 🧩 Integration with .NET dependency injection and popular serializers
- 🧪 High test coverage and reliability under concurrency
- 🛠️ Extensible abstractions for custom event types and adapters

## 📁 Directory Structure
- `src/` – Core library source
- `tests/` – Unit/integration tests
- `examples/` – Usage examples
- `docs/` – Documentation

## ✨ Features
- ⚡ **Thread-safe, lock-free event sequencing** (global & per-stream)
- 🧊 **Immutable, well-documented domain events**
- 🛡️ **Guard-clause parameter validation**
- 🏭 **Factory pattern for event creation**
- 🔄 **System.Numerics.Vector3 adapters** for Unity/numerics integration
- 🧪 **100% tested** with high concurrency coverage
- 🚀 **Example projects** for rapid onboarding

## Serializer Support

EventStreaming supports pluggable event serialization via the `IEventSerializer` abstraction. You can choose between:

- **System.Text.Json** (recommended for .NET Core/Standard):
  - Register with DI: `services.AddSystemTextJsonEventSerializer()`
  - Or use manually: `new SystemTextJsonEventSerializer()`
- **Newtonsoft.Json (JsonNet)** (recommended for Unity/legacy):
  - Use manually: `new JsonNetEventSerializer()`
  - No DI helper provided (manual registration only)

See [docs/serialization.md](docs/serialization.md) for details, usage, and comparison.

## 🛠️ Abstractions
- `IEvent` (immutable, sequence, stream, tag)
- `IEventSequencer` (thread-safe, global)
- `IStreamSequencer` (per-stream)

## 🧱 Core Implementation
- `EventBase` (abstract, immutable)
- `EventSequencer` (lock-free, global)
- `StreamSequencer` (per-stream)

## 🧰 Utilities
- `Guard` static class for parameter validation (`NotNull`, `NotDefault`)

## 🔬 Concurrency & Robustness
- Sequencers are thread-safe and tested under heavy parallel load
- High-concurrency stress tests ensure reliability in real-world scenarios

## 🎮 Domain Events
- `Vector3DEvent` (double x, y, z) for 3D spatial data
- `RotationEvent` (double pitch, yaw, roll) for rotation/orientation
- Both are immutable, fully tested, and support data-driven numeric accuracy

## 🚦 Continuous Integration (CI)

This project uses GitHub Actions for automated build and test verification. On every push or pull request to the `master` branch:

- All projects are restored, built, and tested on Windows using the latest .NET SDK.
- The build status badge at the top of this README reflects the current CI status.
- PRs and commits must have all tests passing for a successful build.

You can find the workflow definition in [.github/workflows/build.yml](.github/workflows/build.yml).

## 🧪 Testing
- 100% code coverage target
- Tests live in `/tests/EventStreaming.Tests/` mirroring the main app structure

## ✅ Test Status
- All core abstractions and implementations are fully covered by unit tests
- Tests pass on .NET 7.0 (xUnit)

## 📖 Documentation
- [User Guide](docs/usage.md)
- [API Reference](docs/API.md)
- [Changelog](CHANGELOG.md)
- [Examples](examples/)
- [Project Tasks](TASK.md)

## 🚀 Quick Start
See [docs/usage.md](docs/usage.md) for installation and usage instructions.

### 🧩 Dependency Injection

If you are using Microsoft.Extensions.DependencyInjection, simply add the optional package and register services:

```csharp
using Microsoft.Extensions.DependencyInjection;
using EventStreaming.DependencyInjection;

var services = new ServiceCollection();
services.AddEventStreaming(); // Registers sequencers, factories, adapters, etc.
```

See the [full DI documentation](docs/dependencyinjection.md) for advanced scenarios and customization.

---

## 🔄 Serialization Examples

### Using Newtonsoft.Json (Json.NET)
```csharp
using Newtonsoft.Json;
using EventStreaming.Events;

var evt = new Vector3DEvent(1, 42, "move", 1.0, 2.0, 3.0);
string json = JsonConvert.SerializeObject(evt);
// Deserialize
var evt2 = JsonConvert.DeserializeObject<Vector3DEvent>(json);
```

### Using System.Text.Json
```csharp
using System.Text.Json;
using EventStreaming.Events;

var evt = new Vector3DEvent(1, 42, "move", 1.0, 2.0, 3.0);
string json = JsonSerializer.Serialize(evt);
// Deserialize
var evt2 = JsonSerializer.Deserialize<Vector3DEvent>(json);
```

> Note: All event types are simple, immutable records and serialize cleanly with both libraries. For advanced scenarios (polymorphic events, custom converters), see the API docs.

---

## 🔭 Future Updates
- 🔌 **Pluggable serializer abstractions** (`IEventSerializer`)
- 🧬 **Source-generator** to auto-create event records
- 🧩 **Out-of-order replay buffer** with gap detection
- 🎮 **Unity package** & sample scene
- 🛠️ **Custom JSON converters** for polymorphic or versioned events
- 🌐 **Distributed event streaming adapters**

See [TASK.md](TASK.md#future-ideas) for more!

---

## 🗺️ Release & Roadmap
- See [CHANGELOG.md](CHANGELOG.md) for version history.
- See [TASK.md](TASK.md) for planned features and roadmap.

## 🙋 Questions & Contributions
For questions, suggestions, or contributions, check the documentation or open an issue.

## 📝 License
MIT (see LICENCE file)
