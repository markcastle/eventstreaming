# EventStreaming Work Board  
Use the checkboxes…  
**Legend:** 🔹 Backlog | 🟡 In&nbsp;Progress | ⛔️ Blocked | ✅ Done  
Add additional discovered tasks upon discovery.

---

## EPIC 0 – Repository Bootstrap

- [x] ✅ Create mono-repo with `src/`, `tests/`, `examples/`, `docs/`. (2025-04-25)  
- [x] ✅ Add `.editorconfig`, `.gitignore`, licence (MIT), `README.md`. (2025-04-25)

---

## EPIC 1 – Abstractions (v0.1)

- [x] ✅ `IEvent` interface (immutable, generic payload variant?). (2025-04-25)  
- [x] ✅ `IEventSequencer` interface – thread-safe, global. (2025-04-25)  
- [x] ✅ `IStreamSequencer` interface – per-stream. (2025-04-25)  
- [x] ✅ XML docs for every public symbol. (2025-04-25)  
- [x] ✅ Unit tests → `EventStreaming.Abstractions.Tests` (target 100 %). (2025-04-25)  

---

## EPIC 2 – Core Implementation (v0.3)

- [x] ✅ `EventBase` (implements `IEvent`; stores seq/stream/tag). (2025-04-25)  
- [x] ✅ `EventSequencer` (lock-free atomic increment; starts at 1 by default). (2025-04-25)  
- [x] ✅ `StreamSequencer` (ConcurrentDictionary\<int,long>). (2025-04-25)  
- [x] ✅ Guard-clause library (null/struct default). (2025-04-25)  
- [x] ✅ High-concurrency stress test (xUnit + `Parallel.For`). (2025-04-25)  
- [x] ✅ >95 % branch coverage on core. (2025-04-25)

---

## EPIC 3 – Domain Events (v0.3)

- [x] ✅ `Vector3DEvent` (double x, y, z). (2025-04-25)  
- [x] ✅ `RotationEvent` (double pitch, yaw, roll). (2025-04-25)  
- [x] ✅ Data-driven tests (theory) for numeric accuracy. (2025-04-25)

---

## EPIC 4 – Factories (v0.4)

- [x] ✅ `EventFactory` (inject `IEventSequencer`). (2025-04-25)  
- [x] ✅ `StreamEventFactory` (inject `IStreamSequencer`). (2025-04-25)  
- [x] ✅ Factories produce domain events with *correct* seq values. (2025-04-25)  
- [x] ✅ Mutation-testing pass with *Stryker* (≥90 %). (2025-04-25)

---

## EPIC 5 – Adapters (v0.4)

- [x] ✅ `SystemNumericsAdapters` (extension methods). (2025-04-25)  
- [x] ✅ Round-tripping tests between `Vector3` and `Vector3DEvent`. (2025-04-25)
- [x] ✅ Add usage examples for System.Numerics adapters in /examples/NumericsIntegrationExample (2025-04-25)
- [x] ✅ Finalize XML documentation for all new types and adapters (2025-04-27)
- [x] ✅ Add DI registration for primitives if required (2025-04-27)
- [x] ✅ Update README and API docs to reference new primitives and usage (2025-04-25)

---

## EPIC 6 – Examples (v0.4)

- [x] ✅ `BasicExample` (single stream). (2025-04-25)  
- [x] ✅ `MultiStreamExample`. (2025-04-25)  
- [x] ✅ `NumericsIntegrationExample` (Unity-style). (2025-04-25)

---

## EPIC 7 – Documentation & Release (v1.0)

- [x] ✅ Populate `CHANGELOG.md`. (2025-04-25)  
- [x] ✅ Write user guide (`docs/usage.md`) referencing `EXAMPLES.md`. (2025-04-25)  
- [x] ✅ API reference doc `docs/API.md`. (2025-04-25)  
- [x] ✅ Version 1.0.0 tag → `dotnet pack` → publish to NuGet. (2025-04-25)  
- [x] ✅ Finalise README referencing all other docs. (2025-04-25)

---

## EPIC 8 – Dependency Injection Support (vNext)

- [x] ✅ Create a new optional project `EventStreaming.DependencyInjection` for DI support. (2025-04-25)
- [x] ✅ Register all core abstractions (sequencers, factories, adapters) with Microsoft.Extensions.DependencyInjection. (2025-04-25)
- [x] ✅ Provide extension methods for easy registration (e.g., `AddEventStreaming()`). (2025-04-25)
- [x] ✅ Ensure full XML documentation for all public APIs. (2025-04-25)
- [x] ✅ Add comprehensive unit tests (xUnit) for DI registration and resolution. (2025-04-25)
- [x] ✅ Write documentation (`docs/dependencyinjection.md`) with usage examples and integration notes. (2025-04-25)
- [x] ✅ Reference DI integration in the main README and user guide. (2025-04-25)

---

## EPIC 9 – Pluggable Serializer Abstractions (vNext)

- [x] ✅ Define `IEventSerializer` interface in the core abstractions. (2025-04-25)
- [x] ✅ Create a new project `EventStreaming.JsonNet` with a concrete implementation using Newtonsoft.Json. (2025-04-25)
- [x] ✅ Create a new project `EventStreaming.SystemTextJson` with a concrete implementation using System.Text.Json. (2025-04-25)
- [x] ✅ Ensure both serializers fully support all event types and are covered by unit tests. (2025-04-25)
- [x] ✅ Add XML documentation for all serializer APIs and public types. (2025-04-25)
- [x] ✅ Provide extension method for easy registration with DI for System.Text.Json only (`AddSystemTextJsonEventSerializer`). (2025-04-25)
- [x] ✅ Write documentation (`docs/serialization.md`) with usage, configuration, and comparison notes. (2025-04-25)
- [x] ✅ Reference serializer support in the main README and user guide. (2025-04-25)
- [x] ✅ Achieve full test coverage for all abstractions, implementations, and integration points. (2025-04-25)

---

## EPIC 10 – Source Generator for Event Records (vNext)

- [ ] ✅ Design source generator API (attribute syntax, conventions, etc).
- [ ] ✅ Create new project `EventStreaming.SourceGenerator` (.NET Standard 2.0+).
- [ ] ✅ Implement Roslyn source generator to auto-create event records from attributes or config.
- [ ] ✅ Ensure generated records implement required interfaces and XML docs.
- [ ] ✅ Add unit and integration tests for generator output.
- [ ] ✅ Provide example usage in `/examples/` and update user guide.
- [ ] ✅ Reference generator in main README and API docs.
- [ ] ✅ Achieve full test coverage and documentation for generator and generated code.

---

## EPIC 11 – Continuous Integration (CI) & Build Automation

- [x] ✅ Design GitHub Actions workflow for .NET build and test. (2025-04-25)
- [x] ✅ Add workflow yaml file to `.github/workflows/` (e.g., `build.yml`). (2025-04-25)
- [x] ✅ Ensure workflow restores, builds, and runs all tests for all projects. (2025-04-25)
- [x] ✅ Badge in README reflects CI status (passing/failing). (2025-04-25)
- [x] ✅ Document CI process and badge in README and developer docs. (2025-04-25)
- [x] ✅ All tests must pass for PRs/commits to main. (2025-04-25)

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

## EPIC 13 – Event Primitives & Patterns Expansion (🟡 In Progress, started 2025-04-26)

- [x] ✅ Create new optional project `EventStreaming.Primitives` for additional event types and adapters. (2025-04-25)
- [x] ✅ Add new project(s) to the solution for full integration and testing. (2025-04-25)
- [x] ✅ Implement event types: Vector2Event, QuaternionEvent, FloatEvent, IntEvent, BoolEvent, StringEvent, ColorEvent, RectEvent, KeyPressEvent, MouseEvent, CompositeEvent, StateChangeEvent, TimedEvent, CommandEvent, CollisionEvent, ErrorEvent, CustomPayloadEvent. (2025-04-27)
- [ ] 🔹 Provide adapters for System.Numerics, Unity, etc.
- [x] ✅ Add unit tests for all new event types and adapters (100% coverage). (2025-04-27)
- [x] ✅ Add usage examples for each new event type in `/examples/`. (2025-04-27)
- [x] ✅ Add XML docs for all new types and adapters. (2025-04-27)
- [x] ✅ Add DI registration for primitives (in existing or new DI project as needed). (2025-04-27)
- [x] ✅ Update README and API docs to reference new primitives and usage.
- [ ] 🔹 Whenever a new primitive event type is added, ensure corresponding builder support and tests are added in `EventStreaming.Builders`. (Added 2025-04-25)

---

## EPIC 14 – Fluent Event Builder & Chaining (🟡 In Progress, started 2025-04-25)

- [x] ✅ Create new project `EventStreaming.Builders` for fluent event builder/chaining APIs. (2025-04-25)
- [x] ✅ Add new project(s) to the solution for full integration and testing. (2025-04-25)
- [x] ✅ Design fluent builder API for composing events (single, composite, batch, etc). (2025-04-25)
- [x] ✅ Implement `EventBuilder<T>`, chaining methods (`Add`, `With`, `OnError`, etc), and composite event logic. (2025-04-25)
- [x] ✅ Add unit tests and integration tests for builder core. (2025-04-25)
- [x] ✅ Ensure thread safety, immutability, and extensibility. (Builder produces immutable events; thread safety is not required for builder usage pattern.)
- [x] ✅ Provide adapters for integrating with existing primitives and core events. (Fluent builder extensions for all primitives implemented and tested)
- [x] ✅ Add unit tests and integration tests for advanced/primitive scenarios (100% coverage). (All builder extension methods tested)
- [x] ✅ Add XML docs for all APIs and builder patterns. (All builder extension methods now have comprehensive XML documentation.)
- [ ] 🔹 Add usage examples and update `/examples/`.
- [ ] 🔹 Update README and API docs to reference fluent builder usage.
- [x] ✅ Consider DI integration for builder registration/configuration. (README and API docs updated with DI usage and registration patterns.)

---

## EPIC: Advanced Event Streaming Features (Planned)

_Discovered During Work (2025-04-27):_
- [ ] 🔹 Add advanced adapters for integration with third-party systems (e.g., Kafka, RabbitMQ, Azure Service Bus).
- [ ] 🔹 Add performance benchmarks and stress tests for event streaming under high concurrency.
- [ ] 🔹 Provide serialization adapters for additional formats (e.g., Protobuf, MessagePack).
- [ ] 🔹 Explore event versioning and migration strategies.
- [ ] 🔹 Add more usage scenarios and best practices to documentation.

---

### ✅ Completed (2025-04-27)
- [x] Provide adapters for integrating with existing primitives and core events.
- [x] Add unit tests and integration tests for advanced/primitive scenarios (100% coverage).
- [x] Add XML docs for all APIs and builder patterns.
- [x] Add usage examples and update `/examples/`.
- [x] Update README and API docs to reference fluent builder usage.
- [x] Consider DI integration for builder registration/configuration.

---

**Next Steps:**
- Review planned advanced features and prioritize for the next EPIC.
- Add new discovered tasks here as development continues.

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

*Last updated: 2025-04-27 (UTC+01:00)*
