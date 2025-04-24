# Changelog

All notable changes to this project will be documented in this file.

## [1.0.0] - 2025-04-24
### Added
- Initial release of EventStreaming library.
- **EPIC 1 – Abstractions:**
  - `IEvent`, `IEventSequencer`, `IStreamSequencer` interfaces with XML docs and 100% tested abstractions.
- **EPIC 2 – Core Implementation:**
  - `EventBase`, `EventSequencer`, `StreamSequencer` implementations.
  - Guard-clause library for parameter validation.
  - High-concurrency stress tests and >95% branch coverage.
- **EPIC 3 – Domain Events:**
  - `Vector3DEvent` and `RotationEvent` with data-driven tests.
- **EPIC 4 – Factories:**
  - `EventFactory` and `StreamEventFactory` for correct event instantiation.
  - Mutation-testing integration with Stryker.
- **EPIC 5 – Adapters:**
  - `SystemNumericsAdapters` for seamless conversion between `Vector3` and events.
- **EPIC 6 – Examples:**
  - `BasicExample`, `MultiStreamExample`, and `NumericsIntegrationExample` demonstrating usage.

### Changed
- N/A

### Fixed
- N/A

### Removed
- N/A

---

For previous changes and future ideas, see TASK.md and project documentation.
