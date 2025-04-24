# Future Complex Event Patterns (Planned)

This document lists complex and widely-used event patterns that are planned for future support in the EventStreaming library. These are not yet implemented, but are under consideration for the roadmap.

## Planned Complex Event Types & Patterns

### State Change Event
- Captures a transition from one value to another.
- Fields: OldValue, NewValue, Timestamp, (optional: User/Source)
- Use cases: Property changes, UI state, config updates, device state.

### Composite Event
- Bundles multiple primitive events or values into a single payload.
- Use cases: Network sync, multi-property updates, frame snapshots.

### Timed/Duration Event
- Associates an event with a timestamp, interval, or duration.
- Use cases: Scheduling, animation, timeouts, metrics.

### Command Event (with Payload)
- Encapsulates an action or command, often with parameters.
- Use cases: CQRS, messaging, remote control, undo/redo.

### Error/Exception Event
- Represents an error, fault, or exception.
- Use cases: Diagnostics, monitoring, user feedback.

### Correlation/Trace Event
- Includes a correlation or trace ID to link related events.
- Use cases: Distributed tracing, debugging, transaction tracking.

### Aggregate/Batch Event
- Represents a group of events processed together.
- Use cases: Bulk processing, network efficiency, analytics.

### Input Sequence/Combo Event
- Captures a sequence of inputs (e.g., key combos, gestures).
- Use cases: Gaming, accessibility, macro recording.

### Collision/Interaction Event
- Represents the interaction between two or more entities.
- Use cases: Physics engines, games, robotics.

### Network/Sync Event
- Used for distributed state sync, includes origin/source info.
- Use cases: Multiplayer games, distributed systems, IoT.

### Lifecycle Event
- Indicates lifecycle transitions (Created, Started, Stopped, Destroyed).
- Use cases: Resource management, object pooling, process control.

### CustomPayload Event
- Strongly-typed or dynamic payload for maximum flexibility.
- Use cases: Extensibility, plugin systems, user-defined events.

---

## Other Patterns to Consider

- **E-commerce Events:** OrderPlaced, PaymentProcessed, CartUpdated, ShipmentDispatched, etc.
- **OpenTelemetry/Observability:** SpanStarted, SpanEnded, MetricRecorded, LogEvent, etc.
- **Workflow/Process Events:** StepStarted, StepCompleted, ApprovalRequested, etc.
- **Domain-Driven Design (DDD):** DomainEvent<T>, AggregateRootChanged, etc.
- **UI/UX Events:** Click, Hover, Focus, Blur, etc.

**If you have suggestions for additional patterns or use cases, please add them here!**

---

*This document is a living roadmap for future event types and patterns in EventStreaming. Contributions and feedback are welcome.*
