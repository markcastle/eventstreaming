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

- [x] 🔹 Define `IEventSerializer` interface in the core abstractions.
- [x] 🔹 Create a new project `EventStreaming.JsonNet` with a concrete implementation using Newtonsoft.Json.
- [x] 🔹 Create a new project `EventStreaming.SystemTextJson` with a concrete implementation using System.Text.Json.
- [x] 🔹 Ensure both serializers fully support all event types and are covered by unit tests.
- [x] 🔹 Add XML documentation for all serializer APIs and public types.
- [x] 🔹 Provide extension method for easy registration with DI for System.Text.Json only (`AddSystemTextJsonEventSerializer`).
- [x] 🔹 Write documentation (`docs/serialization.md`) with usage, configuration, and comparison notes.
- [x] 🔹 Reference serializer support in the main README and user guide.
- [x] ✅ Achieve full test coverage for all abstractions, implementations, and integration points.

---

## EPIC 10 – Source Generator for Event Records (vNext)

- [ ] 🔹 Design source generator API (attribute syntax, conventions, etc).
- [ ] 🔹 Create new project `EventStreaming.SourceGenerator` (.NET Standard 2.0+).
- [ ] 🔹 Implement Roslyn source generator to auto-create event records from attributes or config.
- [ ] 🔹 Ensure generated records implement required interfaces and XML docs.
- [ ] 🔹 Add unit and integration tests for generator output.
- [ ] 🔹 Provide example usage in `/examples` and update user guide.
- [ ] 🔹 Reference generator in main README and API docs.
- [ ] ✅ Achieve full test coverage and documentation for generator and generated code.

---

## EPIC 11 – Continuous Integration (CI) & Build Automation

- [x] 🔹 Design GitHub Actions workflow for .NET build and test.
- [x] 🔹 Add workflow yaml file to `.github/workflows/` (e.g., `build.yml`).
- [x] 🔹 Ensure workflow restores, builds, and runs all tests for all projects.
- [x] 🔹 Badge in README reflects CI status (passing/failing).
- [x] 🔹 Document CI process and badge in README and developer docs.
- [x] ✅ All tests must pass for PRs/commits to main.

---

## Future Ideas

- [X] 🔹 Pluggable serializer abstractions (`IEventSerializer`).  
- [ ] 🔹 Out-of-order replay buffer with gap detection.  
- [ ] 🔹 Unity package + sample scene.  

---

### Discovered During Work
- [x] Ensure test project structure matches planned namespaces and folder hierarchy.

---

*Last updated: 2025-04-24 (UTC+01:00)*
