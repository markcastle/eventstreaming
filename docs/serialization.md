# EventStreaming Serialization Guide

This guide explains how to serialize and deserialize events using the pluggable `IEventSerializer` abstraction, and how to choose between the available implementations.

---

## ✨ Overview

EventStreaming provides a flexible serialization abstraction via the `IEventSerializer` interface. This allows you to use different serialization engines (such as System.Text.Json or Newtonsoft.Json) without coupling your code to a specific library.

---

## 🚀 Quick Start

### Using System.Text.Json (Recommended for .NET Core/Standard)

1. **Register the serializer in DI:**
    ```csharp
    using Microsoft.Extensions.DependencyInjection;
    using Inovus.Messaging.SystemTextJson;

    var services = new ServiceCollection();
    services.AddSystemTextJsonEventSerializer();
    // Now IEventSerializer resolves to SystemTextJsonEventSerializer
    ```

2. **Manual usage:**
    ```csharp
    var serializer = new SystemTextJsonEventSerializer();
    string json = serializer.Serialize(evt);
    var evt2 = serializer.Deserialize<Vector3DEvent>(json);
    ```

### Using Newtonsoft.Json (Recommended for Unity or legacy platforms)

- **Manual usage only:**
    ```csharp
    var serializer = new JsonNetEventSerializer();
    string json = serializer.Serialize(evt);
    var evt2 = serializer.Deserialize<Vector3DEvent>(json);
    ```
- **Note:** There is no DI helper for JsonNet; register manually if required.

---

## 🔄 Choosing a Serializer

| Scenario                | Recommended Serializer           |
|-------------------------|----------------------------------|
| .NET Core/Standard app  | System.Text.Json                 |
| Unity/legacy .NET       | Newtonsoft.Json (JsonNet)        |
| Custom/advanced         | Implement your own IEventSerializer |

- **System.Text.Json**: Fast, modern, built-in to .NET Core, preferred for most apps.
- **Newtonsoft.Json**: Best for Unity, legacy, or when advanced features are needed.

---

## ⚠️ Edge Case Behavior

- **Malformed JSON:** Both serializers throw exceptions on invalid input.
- **Empty string:**
  - System.Text.Json: Throws `JsonException`.
  - Newtonsoft.Json: Returns `null`.
- **Null input:** Both serializers throw `ArgumentNullException`.

---

## 🧪 Testing & Extensibility

- All serializer implementations are covered by comprehensive unit tests.
- You can implement your own serializer by inheriting `IEventSerializer`.

---

## 📚 Further Reading
- [Main README](../README.md)
- [API Reference](API.md)
- [User Guide](usage.md)

For questions or contributions, open an issue or see the main documentation.
