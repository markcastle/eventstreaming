# Unit Testing Examples

This document provides example unit tests for the EventStreaming library components.

## Project Structure

```
EventStreaming.Tests/
├── Core/
│   ├── EventBaseTests.cs
│   ├── EventSequencerTests.cs
│   └── StreamSequencerTests.cs
├── Events/
│   ├── Vector3DEventTests.cs
│   └── RotationEventTests.cs
├── Factories/
│   ├── EventFactoryTests.cs
│   └── StreamEventFactoryTests.cs
└── Adapters/
    └── SystemNumericsAdaptersTests.cs
```

## EventBaseTests Example

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Threading;
using Xunit;
using FluentAssertions;
using EventStreaming;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the EventBase class
    /// </summary>
    public class EventBaseTests
    {
        /// <summary>
        /// Test event implementation that inherits from EventBase
        /// </summary>
        private class TestEvent : EventBase
        {
            public TestEvent() : base() { }
            public TestEvent(int streamId) : base(streamId) { }
            public TestEvent(int streamId, int tag) : base(streamId, tag) { }
            public TestEvent(Guid id, DateTimeOffset timestamp, int streamId, int tag) 
                : base(id, timestamp, streamId, tag) { }
        }

        [Fact]
        public void Constructor_Default_SetsDefaultValues()
        {
            // Arrange & Act
            var evt = new TestEvent();

            // Assert
            evt.Id.Should().NotBe(Guid.Empty);
            evt.StreamId.Should().Be(0);
            evt.Tag.Should().Be(0);
            evt.Timestamp.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1));
            evt.EventType.Should().Be("TestEvent");
            evt.SequenceNumber.Should().Be(0);
        }

        [Fact]
        public void Constructor_WithStreamId_SetsStreamId()
        {
            // Arrange & Act
            var evt = new TestEvent(42);

            // Assert
            evt.StreamId.Should().Be(42);
            evt.Tag.Should().Be(0);
        }

        [Fact]
        public void Constructor_WithStreamIdAndTag_SetsStreamIdAndTag()
        {
            // Arrange & Act
            var evt = new TestEvent(42, 7);

            // Assert
            evt.StreamId.Should().Be(42);
            evt.Tag.Should().Be(7);
        }
        
        [Fact]
        public void Constructor_WithAllParameters_SetsAllProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var timestamp = DateTimeOffset.UtcNow.AddMinutes(-5);
            
            // Act
            var evt = new TestEvent(id, timestamp, 42, 7);
            
            // Assert
            evt.Id.Should().Be(id);
            evt.Timestamp.Should().Be(timestamp);
            evt.StreamId.Should().Be(42);
            evt.Tag.Should().Be(7);
        }

        [Fact]
        public void EventType_ReturnsClassName()
        {
            // Arrange
            var evt = new TestEvent();

            // Act & Assert
            evt.EventType.Should().Be("TestEvent");
        }

        [Fact]
        public void Ids_AreUnique()
        {
            // Arrange & Act
            var evt1 = new TestEvent();
            var evt2 = new TestEvent();

            // Assert
            evt1.Id.Should().NotBe(evt2.Id);
        }
    }
}
```

## EventSequencerTests Example

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using EventStreaming;
using EventStreaming.Events;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the EventSequencer class
    /// </summary>
    public class EventSequencerTests
    {
        [Fact]
        public void AssignSequenceNumber_AssignsSequentialNumbers()
        {
            // Arrange
            var sequencer = new EventSequencer();
            var evt1 = new Vector3DEvent(1, 2, 3);
            var evt2 = new Vector3DEvent(4, 5, 6);
            var evt3 = new Vector3DEvent(7, 8, 9);
            
            // Act
            sequencer.AssignSequenceNumber(evt1);
            sequencer.AssignSequenceNumber(evt2);
            sequencer.AssignSequenceNumber(evt3);
            
            // Assert
            evt1.SequenceNumber.Should().Be(1);
            evt2.SequenceNumber.Should().Be(2);
            evt3.SequenceNumber.Should().Be(3);
        }
        
        [Fact]
        public void CurrentSequence_ReturnsLatestSequenceNumber()
        {
            // Arrange
            var sequencer = new EventSequencer();
            var evt1 = new Vector3DEvent(1, 2, 3);
            var evt2 = new Vector3DEvent(4, 5, 6);
            
            // Act
            sequencer.AssignSequenceNumber(evt1);
            sequencer.AssignSequenceNumber(evt2);
            
            // Assert
            sequencer.CurrentSequence.Should().Be(2);
        }
        
        [Fact]
        public void Constructor_WithStartingSequence_StartsFromSpecifiedValue()
        {
            // Arrange
            var sequencer = new EventSequencer(1000);
            var evt = new Vector3DEvent(1, 2, 3);
            
            // Act
            sequencer.AssignSequenceNumber(evt);
            
            // Assert
            evt.SequenceNumber.Should().Be(1001);
            sequencer.CurrentSequence.Should().Be(1001);
        }
        
        [Fact]
        public async Task AssignSequenceNumber_IsThreadSafe()
        {
            // Arrange
            var sequencer = new EventSequencer();
            var events = new Vector3DEvent[100];
            for (int i = 0; i < events.Length; i++)
            {
                events[i] = new Vector3DEvent(i, i, i);
            }
            
            // Act - assign sequence numbers in parallel
            await Task.WhenAll(
                Task.Run(() => { 
                    for (int i = 0; i < 33; i++) sequencer.AssignSequenceNumber(events[i]); 
                }),
                Task.Run(() => { 
                    for (int i = 33; i < 66; i++) sequencer.AssignSequenceNumber(events[i]); 
                }),
                Task.Run(() => { 
                    for (int i = 66; i < 100; i++) sequencer.AssignSequenceNumber(events[i]); 
                })
            );
            
            // Assert
            // All sequence numbers should be assigned
            for (int i = 0; i < events.Length; i++)
            {
                events[i].SequenceNumber.Should().BeGreaterThan(0);
                events[i].SequenceNumber.Should().BeLessThanOrEqualTo(100);
            }
            
            // All sequence numbers should be unique
            var sequenceNumbers = new System.Collections.Generic.HashSet<long>();
            foreach (var evt in events)
            {
                sequenceNumbers.Add(evt.SequenceNumber).Should().BeTrue(
                    $"Sequence number {evt.SequenceNumber} was assigned to more than one event");
            }
            
            // The set should contain exactly 100 sequence numbers
            sequenceNumbers.Count.Should().Be(100);
            
            // The current sequence should be 100
            sequencer.CurrentSequence.Should().Be(100);
        }
    }
}
```

## StreamSequencerTests Example

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using EventStreaming;
using EventStreaming.Events;

namespace EventStreaming.Tests.Core
{
    /// <summary>
    /// Unit tests for the StreamSequencer class
    /// </summary>
    public class StreamSequencerTests
    {
        [Fact]
        public void AssignSequenceNumber_AssignsSequentialNumbersPerStream()
        {
            // Arrange
            var sequencer = new StreamSequencer();
            var evt1Stream1 = new Vector3DEvent(1, 2, 3, 101);
            var evt2Stream1 = new Vector3DEvent(4, 5, 6, 101);
            var evt1Stream2 = new Vector3DEvent(7, 8, 9, 102);
            var evt2Stream2 = new Vector3DEvent(10, 11, 12, 102);
            
            // Act
            sequencer.AssignSequenceNumber(evt1Stream1);
            sequencer.AssignSequenceNumber(evt2Stream1);
            sequencer.AssignSequenceNumber(evt1Stream2);
            sequencer.AssignSequenceNumber(evt2Stream2);
            
            // Assert
            evt1Stream1.SequenceNumber.Should().Be(1);
            evt2Stream1.SequenceNumber.Should().Be(2);
            evt1Stream2.SequenceNumber.Should().Be(1); // Starts at 1 for the new stream
            evt2Stream2.SequenceNumber.Should().Be(2);
        }
        
        [Fact]
        public void GetCurrentSequence_ReturnsLatestSequenceNumberForStream()
        {
            // Arrange
            var sequencer = new StreamSequencer();
            var evt1Stream1 = new Vector3DEvent(1, 2, 3, 101);
            var evt2Stream1 = new Vector3DEvent(4, 5, 6, 101);
            var evt1Stream2 = new Vector3DEvent(7, 8, 9, 102);
            
            // Act
            sequencer.AssignSequenceNumber(evt1Stream1);
            sequencer.AssignSequenceNumber(evt2Stream1);
            sequencer.AssignSequenceNumber(evt1Stream2);
            
            // Assert
            sequencer.GetCurrentSequence(101).Should().Be(2);
            sequencer.GetCurrentSequence(102).Should().Be(1);
        }
        
        [Fact]
        public void GetCurrentSequence_ReturnsZeroForNonExistentStream()
        {
            // Arrange
            var sequencer = new StreamSequencer();
            
            // Act & Assert
            sequencer.GetCurrentSequence(999).Should().Be(0);
        }
        
        [Fact]
        public async Task AssignSequenceNumber_IsThreadSafe()
        {
            // Arrange
            var sequencer = new StreamSequencer();
            var eventsStream1 = new Vector3DEvent[50];
            var eventsStream2 = new Vector3DEvent[50];
            
            for (int i = 0; i < 50; i++)
            {
                eventsStream1[i] = new Vector3DEvent(i, i, i, 101);
                eventsStream2[i] = new Vector3DEvent(i, i, i, 102);
            }
            
            // Act - assign sequence numbers in parallel
            await Task.WhenAll(
                Task.Run(() => { 
                    for (int i = 0; i < 50; i++) sequencer.AssignSequenceNumber(eventsStream1[i]); 
                }),
                Task.Run(() => { 
                    for (int i = 0; i < 50; i++) sequencer.AssignSequenceNumber(eventsStream2[i]); 
                })
            );
            
            // Assert
            // All sequence numbers for stream 1 should be assigned
            for (int i = 0; i < 50; i++)
            {
                eventsStream1[i].SequenceNumber.Should().BeGreaterThan(0);
                eventsStream1[i].SequenceNumber.Should().BeLessT