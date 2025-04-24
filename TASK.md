# EventStreaming Work Board  
Use the checkboxes…  
**Legend:** 🔹 Backlog | 🟡 In&nbsp;Progress | ⛔️ Blocked | ✅ Done  
Add additional discovered tasks upon discovery.

---

## EPIC 0 – Repository Bootstrap

- [x] 🔹 Create mono-repo with `src/`, `tests/`, `examples/`, `docs/`.  
- [x] 🔹 Add `.editorconfig`, `.gitignore`, licence (MIT), `README.md`.

---

## EPIC 1 – Abstractions (v0.1)

- [ ] 🟡 `IEvent` interface (immutable, generic payload variant?).  
- [ ] 🟡 `IEventSequencer` interface – thread-safe, global.  
- [ ] 🟡 `IStreamSequencer` interface – per-stream.  
- [ ] 🟡 XML docs for every public symbol.  
- [ ] 🟡 Unit tests → `EventStreaming.Abstractions.Tests` (target 100 %).  

---

## EPIC 2 – Core Implementation (v0.3)

- [x] 🔹 `EventBase` (implements `IEvent`; stores seq/stream/tag).  
- [x] 🔹 `EventSequencer` (lock-free atomic increment; starts at 1 by default).  
- [x] 🔹 `StreamSequencer` (ConcurrentDictionary\<int,long>).  
- [x] 🔹 Guard-clause library (null/struct default).  
- [x] ✅ High-concurrency stress test (xUnit + `Parallel.For`).  
- [x] ✅ >95 % branch coverage on core.

---

## EPIC 3 – Domain Events (v0.3)

- [x] 🔹 `Vector3DEvent` (double x, y, z).  
- [x] 🔹 `RotationEvent` (double pitch, yaw, roll).  
- [x] ✅ Data-driven tests (theory) for numeric accuracy.

---

## EPIC 4 – Factories (v0.4)

- [x] 🔹 `EventFactory` (inject `IEventSequencer`).  
- [x] 🔹 `StreamEventFactory` (inject `IStreamSequencer`).  
- [x] 🔹 Factories produce domain events with *correct* seq values.  
- [x] 🟢 Mutation-testing pass with *Stryker* (≥90 %).

---

## EPIC 5 – Adapters (v0.4)

- [x] 🔹 `SystemNumericsAdapters` (extension methods).  
- [x] ✅ Round-tripping tests between `Vector3` and `Vector3DEvent`.

---

## EPIC 6 – Examples (v0.4)

- [x] 🔹 `BasicExample` (single stream).  
- [x] 🔹 `MultiStreamExample`.  
- [x] ✅ `NumericsIntegrationExample` (Unity-style).

---

## EPIC 7 – Documentation & Release (v1.0)

- [x] 🔹 Populate `CHANGELOG.md`.  
- [x] 🔹 Write user guide (`docs/usage.md`) referencing `EXAMPLES.md`.  
- [x] 🔹 API reference doc `docs/API.md`.  
- [x] 🔹 Version 1.0.0 tag → `dotnet pack` → publish to NuGet.  
- [x] 🔹 Finalise README referencing all other docs.

---

## EPIC 8 – Dependency Injection Support (vNext)

- [x] 🔹 Create a new optional project `EventStreaming.DependencyInjection` for DI support.
- [x] 🔹 Register all core abstractions (sequencers, factories, adapters) with Microsoft.Extensions.DependencyInjection.
- [x] 🔹 Provide extension methods for easy registration (e.g., `AddEventStreaming()`).
- [x] 🔹 Ensure full XML documentation for all public APIs.
- [x] 🔹 Add comprehensive unit tests (xUnit) for DI registration and resolution.
- [x] 🔹 Write documentation (`docs/dependencyinjection.md`) with usage examples and integration notes.
- [x] 🔹 Reference DI integration in the main README and user guide.

---

## EPIC 9 – Pluggable Serializer Abstractions (vNext)

- [ ] 🔹 Define `IEventSerializer` interface in the core abstractions.
- [ ] 🔹 Create a new project `EventStreaming.JsonNet` with a concrete implementation using Newtonsoft.Json.
- [ ] 🔹 Create a new project `EventStreaming.SystemTextJson` with a concrete implementation using System.Text.Json.
- [ ] 🔹 Ensure both serializers fully support all event types and are covered by unit tests.
- [ ] 🔹 Add XML documentation for all serializer APIs and public types.
- [ ] 🔹 Provide extension methods for easy registration with DI (optionally integrate with `EventStreaming.DependencyInjection`).
- [ ] 🔹 Write documentation (`docs/serialization.md`) with usage, configuration, and comparison notes.
- [ ] 🔹 Reference serializer support in the main README and user guide.
- [ ] ✅ Achieve full test coverage for all abstractions, implementations, and integration points.

---

## Future Ideas

- [ ] 🔹 Pluggable serializer abstractions (`IEventSerializer`).  
- [ ] 🔹 Source-generator to auto-create event records.  
- [ ] 🔹 Out-of-order replay buffer with gap detection.  
- [ ] 🔹 Unity package + sample scene.  

---

### Discovered During Work
- [x] Ensure test project structure matches planned namespaces and folder hierarchy.

---

*Last updated: 2025-04-24 (UTC+01:00)*
