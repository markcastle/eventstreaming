# 🎉 EventStreaming

A robust, high-performance .NET library for event sequencing, streaming, and domain event modeling. Built for reliability, concurrency, and extensibility—perfect for games, simulations, distributed systems, and more!

---

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

---

## 🔄 Serialization Examples

### Using Newtonsoft.Json (Json.NET)
```csharp
using Newtonsoft.Json;
using Inovus.Messaging.Events;

var evt = new Vector3DEvent(1, 42, "move", 1.0, 2.0, 3.0);
string json = JsonConvert.SerializeObject(evt);
// Deserialize
var evt2 = JsonConvert.DeserializeObject<Vector3DEvent>(json);
```

### Using System.Text.Json
```csharp
using System.Text.Json;
using Inovus.Messaging.Events;

var evt = new Vector3DEvent(1, 42, "move", 1.0, 2.0, 3.0);
string json = JsonSerializer.Serialize(evt);
// Deserialize
var evt2 = JsonSerializer.Deserialize<Vector3DEvent>(json);
```

> **Note:** All event types are simple, immutable records and serialize cleanly with both libraries. For advanced scenarios (polymorphic events, custom converters), see the API docs.

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
