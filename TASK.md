# EventStreaming Work Board  
Use the checkboxes…  
**Legend:** 🔹 Backlog | 🟡 In&nbsp;Progress | ⛔️ Blocked | ✅ Done  
Add additional discovered tasks upon discovery.

---

## EPIC 0 – Repository Bootstrap

- [x] ✅ Create mono-repo with `src/`, `tests/`, `examples/`, `docs/`.  
- [x] ✅ Add `.editorconfig`, `.gitignore`, licence (MIT), `README.md`.

---

## EPIC 1 – Abstractions (v0.1)

- [x] ✅ `IEvent` interface (immutable, generic payload variant?).  
- [x] ✅ `IEventSequencer` interface – thread-safe, global.  
- [x] ✅ `IStreamSequencer` interface – per-stream.  
- [x] ✅ XML docs for every public symbol.  
- [x] ✅ Unit tests → `EventStreaming.Abstractions.Tests` (target 100 %).  

---

## EPIC 2 – Core Implementation (v0.3)

- [x] ✅ `EventBase` (implements `IEvent`; stores seq/stream/tag).  
- [x] ✅ `EventSequencer` (lock-free atomic increment; starts at 1 by default).  
- [x] ✅ `StreamSequencer` (ConcurrentDictionary\<int,long>).  
- [x] ✅ Guard-clause library (null/struct default).  
- [x] ✅ High-concurrency stress test (xUnit + `Parallel.For`).  
- [x] ✅ >95 % branch coverage on core.

---

## EPIC 3 – Domain Events (v0.3)

- [x] ✅ `Vector3DEvent` (double x, y, z).  
- [x] ✅ `RotationEvent` (double pitch, yaw, roll).  
- [x] ✅ Data-driven tests (theory) for numeric accuracy.

---

## EPIC 4 – Factories (v0.4)

- [x] ✅ `EventFactory` (inject `IEventSequencer`).  
- [x] ✅ `StreamEventFactory` (inject `IStreamSequencer`).  
- [x] ✅ Factories produce domain events with *correct* seq values.  
- [x] ✅ Mutation-testing pass with *Stryker* (≥90 %).

---

## EPIC 5 – Adapters (v0.4)

- [x] ✅ `SystemNumericsAdapters` (extension methods).  
- [x] ✅ Round-tripping tests between `Vector3` and `Vector3DEvent`.

---

## EPIC 6 – Examples (v0.4)

- [x] ✅ `BasicExample` (single stream).  
- [x] ✅ `MultiStreamExample`.  
- [x] ✅ `NumericsIntegrationExample` (Unity-style).

---

## EPIC 7 – Documentation & Release (v1.0)

- [x] ✅ Populate `CHANGELOG.md`.  
- [x] ✅ Write user guide (`docs/usage.md`) referencing `EXAMPLES.md`.  
- [x] ✅ API reference doc `docs/API.md`.  
- [x] ✅ Version 1.0.0 tag → `dotnet pack` → publish to NuGet.  
- [x] ✅ Finalise README referencing all other docs.

---

## EPIC 8 – Dependency Injection Support (vNext)

- [x] ✅ Create a new optional project `EventStreaming.DependencyInjection` for DI support.
- [x] ✅ Register all core abstractions (sequencers, factories, adapters) with Microsoft.Extensions.DependencyInjection.
- [x] ✅ Provide extension methods for easy registration (e.g., `AddEventStreaming()`).
- [x] ✅ Ensure full XML documentation for all public APIs.
- [x] ✅ Add comprehensive unit tests (xUnit) for DI registration and resolution.
- [x] ✅ Write documentation (`docs/dependencyinjection.md`) with usage examples and integration notes.
- [x] ✅ Reference DI integration in the main README and user guide.

---

## EPIC 9 – Pluggable Serializer Abstractions (vNext)

- [x] ✅ Define `IEventSerializer` interface in the core abstractions.
- [x] ✅ Create a new project `EventStreaming.JsonNet` with a concrete implementation using Newtonsoft.Json.
- [x] ✅ Create a new project `EventStreaming.SystemTextJson` with a concrete implementation using System.Text.Json.
- [x] ✅ Ensure both serializers fully support all event types and are covered by unit tests.
- [x] ✅ Add XML documentation for all serializer APIs and public types.
- [x] ✅ Provide extension method for easy registration with DI for System.Text.Json only (`AddSystemTextJsonEventSerializer`).
- [x] ✅ Write documentation (`docs/serialization.md`) with usage, configuration, and comparison notes.
- [x] ✅ Reference serializer support in the main README and user guide.
- [x] ✅ Achieve full test coverage for all abstractions, implementations, and integration points.

---

## EPIC 10 – Source Generator for Event Records (vNext)

- [ ] ✅ Design source generator API (attribute syntax, conventions, etc).
- [ ] ✅ Create new project `EventStreaming.SourceGenerator` (.NET Standard 2.0+).
- [ ] ✅ Implement Roslyn source generator to auto-create event records from attributes or config.
- [ ] ✅ Ensure generated records implement required interfaces and XML docs.
- [ ] ✅ Add unit and integration tests for generator output.
- [ ] ✅ Provide example usage in `/examples` and update user guide.
- [ ] ✅ Reference generator in main README and API docs.
- [ ] ✅ Achieve full test coverage and documentation for generator and generated code.

---

## EPIC 11 – Continuous Integration (CI) & Build Automation

- [x] ✅ Design GitHub Actions workflow for .NET build and test.
- [x] ✅ Add workflow yaml file to `.github/workflows/` (e.g., `build.yml`).
- [x] ✅ Ensure workflow restores, builds, and runs all tests for all projects.
- [x] ✅ Badge in README reflects CI status (passing/failing).
- [x] ✅ Document CI process and badge in README and developer docs.
- [x] ✅ All tests must pass for PRs/commits to main.

---

## EPIC 12 – Simple Generic Event Buffer (POC)

- [ ] 🔹 Create new project `EventStreaming.Buffering` in the solution to contain buffer code and tests.
- [ ] 🔹 Add new project(s) to the solution for full integration and testing.
- [ ] 🔹 Configure project dependencies and references for the new projects.
- [ ] 🔹 Place `ISimpleEventBuffer<T>` interface in `EventStreaming.Abstractions` for maximum reusability and modularity.
- [ ] 🔹 Define `ISimpleEventBuffer<T>` interface with `Enqueue(T item)` and optional `Count` property.
- [ ] 🔹 Implement `SimpleEventBuffer<T>` using `ConcurrentQueue<T>` and background worker (with `Action<T>` or `Func<T, Task>` processor).
- [ ] 🔹 Provide static helper/extension for easy use.
- [ ] 🔹 Create new console example app demonstrating buffer usage (like existing examples).
- [ ] 🔹 Ensure 100% unit test coverage for all buffer code (enqueue, process, concurrency, edge cases).
- [ ] 🔹 Add integration test with custom event type.
- [ ] 🔹 Add XML docs for all APIs.
- [ ] 🔹 Update README and add `docs/buffering.md` with usage and example.
- [ ] 🔹 Ensure all new code and docs are referenced in main README and user guide.

---

## EPIC 13 – Event Primitives & Patterns Expansion

- [ ] 🔹 Create new optional project `EventStreaming.Primitives` for additional event types and adapters.
- [ ] 🔹 Add new project(s) to the solution for full integration and testing.
- [ ] 🔹 Implement event types: Vector2, Quaternion, Float, Int, Bool, String, Color, Rect, KeyPress, Mouse, Composite, StateChange, Timed, Command, Collision, Error, CustomPayload, etc.
- [ ] 🔹 Provide adapters for System.Numerics, Unity, etc.
- [ ] 🔹 Add unit tests for all new event types and adapters (100% coverage).
- [ ] 🔹 Add usage examples for each new event type in `/examples/`.
- [ ] 🔹 Add XML docs for all new types and adapters.
- [ ] 🔹 Add DI registration for primitives (in existing or new DI project as needed).
- [ ] 🔹 Update README and API docs to reference new primitives and usage.

---

## EPIC 14 – Fluent Event Builder & Chaining

- [ ] 🔹 Create new project `EventStreaming.Builders` for fluent event builder/chaining APIs.
- [ ] 🔹 Add new project(s) to the solution for full integration and testing.
- [ ] 🔹 Design fluent builder API for composing events (single, composite, batch, etc).
- [ ] 🔹 Implement `EventBuilder<T>`, `EventBatchBuilder`, and chaining methods (`Add`, `With`, `OnError`, etc).
- [ ] 🔹 Ensure thread safety, immutability, and extensibility.
- [ ] 🔹 Provide adapters for integrating with existing primitives and core events.
- [ ] 🔹 Add unit tests and integration tests (100% coverage).
- [ ] 🔹 Add XML docs for all APIs and builder patterns.
- [ ] 🔹 Add usage examples and update `/examples/`.
- [ ] 🔹 Update README and API docs to reference fluent builder usage.
- [ ] 🔹 Consider DI integration for builder registration/configuration.

---

## Future Ideas

- [X] ✅ Pluggable serializer abstractions (`IEventSerializer`).  
- [ ] 🔹 Out-of-order replay buffer with gap detection.  
- [ ] 🔹 Unity package + sample scene.  
- [ ] 🔹 Explore and implement support for complex/common event patterns (see FUTURE-COMPLEX-EVENTS.md for planned types and patterns).

---

### Discovered During Work
- [x] ✅ Ensure test project structure matches planned namespaces and folder hierarchy.

---

*Last updated: 2025-04-24 (UTC+01:00)*
