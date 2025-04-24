<!-- PLANNING.md -->

# EventStreaming Library – Development Plan  
**Namespace root:** `EventStreaming` | **Target TFM:** `.NET Standard 2.1` | **Language:** `langversion=latest` 

> **Purpose** Deliver a lightweight, fully-tested event–stream sequencing library that can be embedded in any .NET application 
(desktop, mobile, game, server, IoT) without forcing a concrete transport, serializer, or DI container.
Aim for full Code Coverage, SOLID, YAGNI, KISS

---

---

## 1 Architecture Overview

EventStreaming/
├── src/
│   ├── EventStreaming/                            # Assembly: EventStreaming
│   │   ├── Core/                                  # Namespace: EventStreaming
│   │   │   ├── IEvent.cs
│   │   │   ├── EventBase.cs
│   │   │   ├── IEventSequencer.cs
│   │   │   ├── EventSequencer.cs
│   │   │   ├── IStreamSequencer.cs
│   │   │   └── StreamSequencer.cs
│   │   ├── Events/                                # Namespace: EventStreaming.Events
│   │   │   ├── Vector3DEvent.cs
│   │   │   └── RotationEvent.cs
│   │   ├── Factories/                             # Namespace: EventStreaming.Factories
│   │   │   ├── EventFactory.cs
│   │   │   └── StreamEventFactory.cs
│   │   └── Adapters/                              # Namespace: EventStreaming.Adapters
│   │       └── SystemNumericsAdapters.cs
│   └── EventStreaming.Examples/                   # Assembly: EventStreaming.Examples
│       ├── BasicExample.cs                        # Namespace: EventStreaming.Examples
│       ├── MultiStreamExample.cs
│       └── NumericsIntegrationExample.cs
├── tests/
│   └── EventStreaming.Tests/                      # Assembly: EventStreaming.Tests
│       ├── Core/                                  # Namespace: EventStreaming.Tests.Core
│       │   ├── EventBaseTests.cs
│       │   ├── EventSequencerTests.cs
│       │   └── StreamSequencerTests.cs
│       ├── Events/                                # Namespace: EventStreaming.Tests.Events
│       │   ├── Vector3DEventTests.cs
│       │   └── RotationEventTests.cs
│       ├── Factories/                             # Namespace: EventStreaming.Tests.Factories
│       │   ├── EventFactoryTests.cs
│       │   └── StreamEventFactoryTests.cs
│       └── Adapters/                              # Namespace: EventStreaming.Tests.Adapters
│           └── SystemNumericsAdaptersTests.cs

Take note of.. 

MODELS.md
EXAMPLES.md
IMPLEMENTATION.md
UNITTESTINGEXAMPLES.md
COMPATABILITYADAPTDORS.md

and follow the plan....

TASK.md