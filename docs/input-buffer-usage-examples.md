# Input Buffer Usage Examples

## 1. Basic InputBuffer Usage
```csharp
var buffer = new InputBuffer<string>();
buffer.RegisterHandler(async evt =>
{
    Console.WriteLine($"Received: {evt}");
    await Task.CompletedTask;
});
buffer.Enqueue("foo");
buffer.Enqueue("bar");
```

## 2. BatchingInputBuffer Usage
```csharp
var batchBuffer = new BatchingInputBuffer<int>(batchSize: 3);
batchBuffer.RegisterHandler(async batch =>
{
    Console.WriteLine($"Batch: [{string.Join(", ", batch)}]");
    await Task.CompletedTask;
});
for (int i = 0; i < 7; i++)
    batchBuffer.Enqueue(i);
```

## 3. FilteringInputBuffer Usage
```csharp
var filterBuffer = new FilteringInputBuffer<int>(filter: i => i % 2 == 0);
filterBuffer.RegisterHandler(async evt =>
{
    Console.WriteLine($"Even: {evt}");
    await Task.CompletedTask;
});
for (int i = 0; i < 5; i++)
    filterBuffer.Enqueue(i);
```

## 4. Deduplication with FilteringInputBuffer
```csharp
var dedupeBuffer = new FilteringInputBuffer<string>(comparer: StringComparer.OrdinalIgnoreCase);
dedupeBuffer.RegisterHandler(async evt =>
{
    Console.WriteLine($"Unique: {evt}");
    await Task.CompletedTask;
});
dedupeBuffer.Enqueue("a");
dedupeBuffer.Enqueue("A"); // Will be ignored
```

## 5. Using MockEventReceiver
```csharp
var buffer = new InputBuffer<int>();
buffer.RegisterHandler(async evt =>
{
    Console.WriteLine($"Received: {evt}");
    await Task.CompletedTask;
});
var receiver = new MockEventReceiver<int>(i => i * 10, count: 5, interval: TimeSpan.FromMilliseconds(100));
await receiver.StartAsync(buffer);
// ... later
await receiver.StopAsync();
```
