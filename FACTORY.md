# EventStreaming Factory Implementations

This document describes the factory classes that simplify event creation in the EventStreaming library.

## Project Structure

```
EventStreaming/
├── Factories/
│   ├── EventFactory.cs
│   └── StreamEventFactory.cs
```

## EventFactory Implementation

The `EventFactory` class provides methods for creating and sequencing events using a global sequencer:

```csharp
// Copyright (c) 2025 Inovus. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using Inovus.Messaging.Events;

namespace Inovus.Messaging.Factories
{
    /// <summary>
    /// Factory for creating and sequencing events with a global sequencer.
    /// Provides convenience methods for creating common event types.
    /// </summary>
    public class EventFactory
    {
        private readonly IEventSequencer _sequencer;
        private readonly int _defaultStreamId;
        private readonly int _defaultTag;
        
        /// <summary>
        /// Creates a new EventFactory with a default sequencer and no stream/tag
        /// </summary>
        public EventFactory() : this(new EventSequencer(), 0, 0) { }
        
        /// <summary>
        /// Creates a new EventFactory with a specific sequencer
        /// </summary>
        /// <param name="sequencer">The sequencer to use</param>
        public EventFactory(IEventSequencer sequencer) : this(sequencer, 0, 0) { }
        
        /// <summary>
        /// Creates a new EventFactory with default sequencer and specified stream
        /// </summary>
        /// <param name="streamId">The default stream identifier to use</param>
        public EventFactory(int streamId) : this(new EventSequencer(), streamId, 0) { }
        
        /// <summary>
        /// Creates a new EventFactory with default sequencer and specified stream and tag
        /// </summary>
        /// <param name="streamId">The default stream identifier to use</param>
        /// <param name="tag">The default tag to use</param>
        public EventFactory(int streamId, int tag) : this(new EventSequencer(), streamId, tag) { }
        
        /// <summary>
        /// Creates a new EventFactory with specified sequencer, stream and tag
        /// </summary>
        /// <param name="sequencer">The sequencer to use</param>
        /// <param name="streamId">The default stream identifier to use</param>
        /// <param name="tag">The default tag to use</param>
        public EventFactory(IEventSequencer sequencer, int streamId, int tag)
        {
            _sequencer = sequencer;
            _defaultStreamId = streamId;
            _defaultTag = tag;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z)
        {
            var vector = new Vector3DEvent(x, y, z, _defaultStreamId, _defaultTag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event with specific stream
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z, int streamId)
        {
            var vector = new Vector3DEvent(x, y, z, streamId, _defaultTag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event with specific stream and tag
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <param name="tag">Tag for sub-categorizing within a stream</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z, int streamId, int tag)
        {
            var vector = new Vector3DEvent(x, y, z, streamId, tag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, _defaultStreamId, _defaultTag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event with specific stream
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ, int streamId)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, streamId, _defaultTag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event with specific stream and tag
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <param name="tag">Tag for sub-categorizing within a stream</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ, int streamId, int tag)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, streamId, tag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a custom event instance
        /// </summary>
        /// <typeparam name="T">The event type</typeparam>
        /// <param name="createEvent">Function to create the event</param>
        /// <returns>A sequenced event of type T</returns>
        public T CreateEvent<T>(Func<T> createEvent) where T : IEvent
        {
            var evt = createEvent();
            _sequencer.AssignSequenceNumber(evt);
            return evt;
        }
        
        /// <summary>
        /// Assigns a sequence number to an existing event
        /// </summary>
        /// <param name="event">The event to sequence</param>
        public void AssignSequenceNumber(IEvent @event)
        {
            _sequencer.AssignSequenceNumber(@event);
        }
        
        /// <summary>
        /// Gets the current sequence number
        /// </summary>
        public long CurrentSequence => _sequencer.CurrentSequence;
    }
}
```

## StreamEventFactory Implementation

The `StreamEventFactory` class provides methods for creating and sequencing events using stream-specific sequencing:

```csharp
// Copyright (c) 2025 Inovus. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using Inovus.Messaging.Events;

namespace Inovus.Messaging.Factories
{
    /// <summary>
    /// Factory for creating and sequencing events with stream-specific sequencing.
    /// This factory uses IStreamSequencer to maintain separate sequence counters for each stream.
    /// </summary>
    public class StreamEventFactory
    {
        private readonly IStreamSequencer _sequencer;
        private readonly int _defaultStreamId;
        private readonly int _defaultTag;
        
        /// <summary>
        /// Creates a new StreamEventFactory with default settings
        /// </summary>
        public StreamEventFactory() : this(new StreamSequencer(), 0, 0) { }
        
        /// <summary>
        /// Creates a new StreamEventFactory with specified stream
        /// </summary>
        /// <param name="streamId">The default stream identifier to use</param>
        public StreamEventFactory(int streamId) : this(new StreamSequencer(), streamId, 0) { }
        
        /// <summary>
        /// Creates a new StreamEventFactory with specified stream and tag
        /// </summary>
        /// <param name="streamId">The default stream identifier to use</param>
        /// <param name="tag">The default tag to use</param>
        public StreamEventFactory(int streamId, int tag) : this(new StreamSequencer(), streamId, tag) { }
        
        /// <summary>
        /// Creates a new StreamEventFactory with specified sequencer, stream and tag
        /// </summary>
        /// <param name="sequencer">The stream sequencer to use</param>
        /// <param name="streamId">The default stream identifier to use</param>
        /// <param name="tag">The default tag to use</param>
        public StreamEventFactory(IStreamSequencer sequencer, int streamId, int tag)
        {
            _sequencer = sequencer;
            _defaultStreamId = streamId;
            _defaultTag = tag;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z)
        {
            var vector = new Vector3DEvent(x, y, z, _defaultStreamId, _defaultTag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event with specific stream
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z, int streamId)
        {
            var vector = new Vector3DEvent(x, y, z, streamId, _defaultTag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Vector3D event with specific stream and tag
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <param name="tag">Tag for sub-categorizing within a stream</param>
        /// <returns>A sequenced Vector3D event</returns>
        public Vector3DEvent CreateVector3D(double x, double y, double z, int streamId, int tag)
        {
            var vector = new Vector3DEvent(x, y, z, streamId, tag);
            _sequencer.AssignSequenceNumber(vector);
            return vector;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, _defaultStreamId, _defaultTag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event with specific stream
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ, int streamId)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, streamId, _defaultTag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a new Rotation event with specific stream and tag
        /// </summary>
        /// <param name="rotationX">Rotation around X axis in radians</param>
        /// <param name="rotationY">Rotation around Y axis in radians</param>
        /// <param name="rotationZ">Rotation around Z axis in radians</param>
        /// <param name="streamId">Stream identifier for routing</param>
        /// <param name="tag">Tag for sub-categorizing within a stream</param>
        /// <returns>A sequenced Rotation event</returns>
        public RotationEvent CreateRotation(double rotationX, double rotationY, double rotationZ, int streamId, int tag)
        {
            var rotation = new RotationEvent(rotationX, rotationY, rotationZ, streamId, tag);
            _sequencer.AssignSequenceNumber(rotation);
            return rotation;
        }
        
        /// <summary>
        /// Creates and sequences a custom event instance
        /// </summary>
        /// <typeparam name="T">The event type</typeparam>
        /// <param name="createEvent">Function to create the event</param>
        /// <returns>A sequenced event of type T</returns>
        public T CreateEvent<T>(Func<T> createEvent) where T : IEvent
        {
            var evt = createEvent();
            _sequencer.AssignSequenceNumber(evt);
            return evt;
        }
        
        /// <summary>
        /// Assigns a sequence number to an existing event
        /// </summary>
        /// <param name="event">The event to sequence</param>
        public void AssignSequenceNumber(IEvent @event)
        {
            _sequencer.AssignSequenceNumber(@event);
        }
        
        /// <summary>
        /// Gets the current sequence number for a stream
        /// </summary>
        /// <param name="streamId">The stream identifier</param>
        /// <returns>The current sequence number for the stream</returns>
        public long GetCurrentSequence(int streamId)
        {
            return _sequencer.GetCurrentSequence(streamId);
        }
        
        /// <summary>
        /// Gets the current sequence number for the default stream
        /// </summary>
        public long CurrentSequence => _sequencer.GetCurrentSequence(_defaultStreamId);
    }
}
```