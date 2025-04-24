# Dependency Injection with EventStreaming

This guide covers integrating EventStreaming with Microsoft.Extensions.DependencyInjection (MS DI) via the optional `EventStreaming.DependencyInjection` package.

---

## 📦 Installation

1. Add a reference to the `EventStreaming.DependencyInjection` project or NuGet package (when available):
   ```xml
   <ProjectReference Include="../src/EventStreaming.DependencyInjection/EventStreaming.DependencyInjection.csproj" />
   ```
2. Ensure your project also references the core `EventStreaming` library.

---

## 🚀 Quick Start

Register all core services in your DI container:

```csharp
using Microsoft.Extensions.DependencyInjection;
using EventStreaming.DependencyInjection;

var services = new ServiceCollection();
services.AddEventStreaming();
```

This registers:
- `IEventSequencer` (singleton)
- `IStreamSequencer` (singleton)
- `EventFactory` (transient)
- `StreamEventFactory` (transient)

Adapters are provided as static extension methods and do not require DI registration.

---

## 🧩 Advanced Scenarios

- **Custom Sequencer Implementations:**
  Override the default registrations before or after calling `AddEventStreaming()`:
  ```csharp
  services.AddSingleton<IEventSequencer, MyCustomSequencer>();
  services.AddEventStreaming();
  // or, call AddEventStreaming() first and then override
  ```
- **Scoped or Singleton Factories:**
  Change the lifetime as needed using `TryAdd`/`Replace` or by registering your own implementation.

---

## 🧪 Testing

- All DI registrations are covered by unit tests in `EventStreaming.DependencyInjection.Tests`.
- Example test:
  ```csharp
  var provider = services.BuildServiceProvider();
  var factory = provider.GetRequiredService<EventFactory>();
  Assert.NotNull(factory);
  ```

---

## 📖 Further Reading
- [Main README](../README.md)
- [API Reference](API.md)
- [User Guide](usage.md)

---

For questions or contributions, open an issue or see the main documentation.
