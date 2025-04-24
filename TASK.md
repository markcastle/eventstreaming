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

- [ ] 🔹 `IEvent` interface (immutable, generic payload variant?).  
- [ ] 🔹 `IEventSequencer` interface – thread-safe, global.  
- [ ] 🔹 `IStreamSequencer` interface – per-stream.  
- [ ] 🔹 XML docs for every public symbol.  
- [ ] 🟡 Unit tests → `EventStreaming.Abstractions.Tests` (target 100 %).  

---

## EPIC 2 – Core Implementation (v0.3)

- [ ] 🔹 `EventBase` (implements `IEvent`; stores seq/stream/tag).  
- [ ] 🔹 `EventSequencer` (lock-free atomic increment).  
- [ ] 🔹 `StreamSequencer` (ConcurrentDictionary\<int,long>).  
- [ ] 🔹 Guard-clause library (null/struct default).  
- [ ] 🟡 High-concurrency stress test (xUnit + `Parallel.For`).  
- [ ] ✅ >95 % branch coverage on core.

---

## EPIC 3 – Domain Events (v0.3)

- [ ] 🔹 `Vector3DEvent` (double x, y, z).  
- [ ] 🔹 `RotationEvent` (double pitch, yaw, roll).  
- [ ] 🟡 Data-driven tests (theory) for numeric accuracy.

---

## EPIC 4 – Factories (v0.4)

- [ ] 🔹 `EventFactory` (inject `IEventSequencer`).  
- [ ] 🔹 `StreamEventFactory` (inject `IStreamSequencer`).  
- [ ] 🔹 Factories produce domain events with *correct* seq values.  
- [ ] 🟡 Mutation-testing pass with *Stryker* (≥90 %).

---

## EPIC 5 – Adapters (v0.4)

- [ ] 🔹 `SystemNumericsAdapters` (extension methods).  
- [ ] 🟡 Round-tripping tests between `Vector3` and `Vector3DEvent`.

---

## EPIC 6 – Examples (v0.4)

- [ ] 🔹 `BasicExample` (single stream).  
- [ ] 🔹 `MultiStreamExample`.  
- [ ] 🔹 `NumericsIntegrationExample` (Unity-style).  

---

## EPIC 7 – Documentation & Release (v1.0)

- [ ] 🔹 Populate `CHANGELOG.md`.  
- [ ] 🔹 Write user guide (`docs/usage.md`) referencing `EXAMPLES.md`.  
- [ ] 🔹 API reference doc `docs/API.md`.  
- [ ] 🔹 Version 1.0.0 tag → `dotnet pack` → publish to NuGet.  
- [ ] 🔹 Finalise README referencing all other docs.

---

## Future Ideas

- [ ] 🔹 Pluggable serializer abstractions (`IEventSerializer`).  
- [ ] 🔹 Source-generator to auto-create event records.  
- [ ] 🔹 Out-of-order replay buffer with gap detection.  
- [ ] 🔹 Unity package + sample scene.  

---

*Last updated: 2025-04-24 (UTC+01:00)*
