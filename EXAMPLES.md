# Example Usage Implementations

This document provides examples of how to use the EventStreaming library in various scenarios.

## Basic Example

```csharp
// Copyright (c) 2025 Inovus. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using Inovus.Messaging;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;

namespace Inovus.Messaging.Examples
{
    /// <summary>
    /// Basic example demonstrating the core functionality
    /// </summary>
    public class BasicExample
    {
        public static void Run()
        {
            Console.WriteLine("=== Basic Example ===");
            
            // Create an event factory
            var factory = new EventFactory(streamId: 101);
            
            // Create some vector events
            var position1 = factory.CreateVector3D(10.5, 0, 15.0);
            var position2 = factory.CreateVector3D(11.0, 0, 16.0);
            
            // Create a rotation event
            var rotation = factory.CreateRotation(0, Math.PI/4, 0); // 45 degrees around Y-axis
            
            // Print event information
            Console.WriteLine($"Position 1: Event #{position1.SequenceNumber} in stream {position1.StreamId}");
            Console.WriteLine($"  Coordinates: ({position1.X}, {position1.Y}, {position1.Z})");
            Console.WriteLine($"  ID: {position1.Id}");
            Console.WriteLine($"  Timestamp: {position1.Timestamp}");
            
            Console.WriteLine($"Position 2: Event #{position2.SequenceNumber} in stream {position2.StreamId}");
            Console.WriteLine($"  Coordinates: ({position2.X}, {position2.Y}, {position2.Z})");
            
            Console.WriteLine($"Rotation: Event #{rotation.SequenceNumber} in stream {rotation.StreamId}");
            Console.WriteLine($"  Angles (rad): X={rotation.RotationX}, Y={rotation.RotationY}, Z={rotation.RotationZ}");
            Console.WriteLine($"  Angles (deg): X={rotation.RotationX * 180 / Math.PI}, " + 
                $"Y={rotation.RotationY * 180 / Math.PI}, Z={rotation.RotationZ * 180 / Math.PI}");
            
            // Create a custom event type
            var customEvent = factory.CreateEvent(() => new CustomEvent("Hello, World!"));
            Console.WriteLine($"Custom event: #{customEvent.SequenceNumber} - {((CustomEvent)customEvent).Message}");
            
            // High precision values
            var preciseVector = factory.CreateVector3D(
                123.456789012345,
                45.6789012345678,
                9.01234567890123
            );
            
            Console.WriteLine($"High precision vector: #{preciseVector.SequenceNumber}");
            Console.WriteLine($"  X: {preciseVector.X}");
            Console.WriteLine($"  Y: {preciseVector.Y}");
            Console.WriteLine($"  Z: {preciseVector.Z}");
        }
        
        // Custom event class for demonstration
        [Serializable]
        private class CustomEvent : EventBase
        {
            public string Message { get; }
            
            public CustomEvent(string message) : base()
            {
                Message = message;
            }
        }
    }
}
```

## Multi-Stream Example

```csharp
// Copyright (c) 2025 Inovus. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Collections.Generic;
using Inovus.Messaging;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;

namespace Inovus.Messaging.Examples
{
    /// <summary>
    /// Example demonstrating multiple streams with stream-specific sequencing
    /// </summary>
    public class MultiStreamExample
    {
        public static void Run()
        {
            Console.WriteLine("=== Multi-Stream Example ===");
            
            // Create a stream sequencer to maintain separate sequences per stream
            var streamSequencer = new StreamSequencer();
            
            // Create factories for different entities in a game scenario
            var playerFactory = new StreamEventFactory(streamSequencer, streamId: 1001, tag: 0);
            var enemy1Factory = new StreamEventFactory(streamSequencer, streamId: 2001, tag: 0);
            var enemy2Factory = new StreamEventFactory(streamSequencer, streamId: 2002, tag: 0);
            var projectileFactory = new StreamEventFactory(streamSequencer, streamId: 3001, tag: 0);
            
            // Simulate player movement (Stream 1001)
            Console.WriteLine("\nPlayer Movement:");
            for (int i = 0; i < 3; i++)
            {
                var pos = playerFactory.CreateVector3D(i * 1.5, 0, i * 2.0);
                var rot = playerFactory.CreateRotation(0, i * 0.1, 0);
                
                Console.WriteLine($"Frame {i+1}:");
                Console.WriteLine($"  Position event #{pos.SequenceNumber}: ({pos.X}, {pos.Y}, {pos.Z})");
                Console.WriteLine($"  Rotation event #{rot.SequenceNumber}: ({rot.RotationX}, {rot.RotationY}, {rot.RotationZ})");
            }
            
            // Simulate enemy 1 movement (Stream 2001)
            Console.WriteLine("\nEnemy 1 Movement:");
            for (int i = 0; i < 2; i++)
            {
                var pos = enemy1Factory.CreateVector3D(-i * 2.0, 0, i * 3.0);
                
                Console.WriteLine($"Frame {i+1}:");
                Console.WriteLine($"  Position event #{pos.SequenceNumber}: ({pos.X}, {pos.Y}, {pos.Z})");
            }
            
            // Simulate enemy 2 movement (Stream 2002)
            Console.WriteLine("\nEnemy 2 Movement:");
            for (int i = 0; i < 2; i++)
            {
                var pos = enemy2Factory.CreateVector3D(i * 3.0, 0, -i * 1.0);
                
                Console.WriteLine($"Frame {i+1}:");
                Console.WriteLine($"  Position event #{pos.SequenceNumber}: ({pos.X}, {pos.Y}, {pos.Z})");
            }
            
            // Simulate projectile launch (Stream 3001)
            Console.WriteLine("\nProjectile:");
            var projectile = projectileFactory.CreateVector3D(1.0, 0.5, 2.0);
            Console.WriteLine($"  Launch event #{projectile.SequenceNumber}: ({projectile.X}, {projectile.Y}, {projectile.Z})");
            
            // Display current sequence numbers for each stream
            Console.WriteLine("\nCurrent sequence numbers per stream:");
            Console.WriteLine($"  Player (1001): {streamSequencer.GetCurrentSequence(1001)}");
            Console.WriteLine($"  Enemy 1 (2001): {streamSequencer.GetCurrentSequence(2001)}");
            Console.WriteLine($"  Enemy 2 (2002): {streamSequencer.GetCurrentSequence(2002)}");
            Console.WriteLine($"  Projectile (3001): {streamSequencer.GetCurrentSequence(3001)}");
            
            // Demonstrate using tags for categorizing events within a stream
            Console.WriteLine("\nUsing tags within a stream:");
            
            // Create a factory for player events with different tags for different types of data
            var playerDetailedFactory = new StreamEventFactory(streamSequencer, streamId: 1001);
            
            // Position events (tag 1)
            var playerPos = playerDetailedFactory.CreateVector3D(5.0, 1.0, 7.0, 1001, 1);
            Console.WriteLine($"  Position event #{playerPos.SequenceNumber} (tag {playerPos.Tag}): ({playerPos.X}, {playerPos.Y}, {playerPos.Z})");
            
            // Health event (tag 2)
            var playerHealth = playerDetailedFactory.CreateEvent(() => new HealthEvent(85.5, 1001, 2));
            Console.WriteLine($"  Health event #{playerHealth.SequenceNumber} (tag {playerHealth.Tag}): {((HealthEvent)playerHealth).CurrentHealth}%");
            
            // Ammunition event (tag 3)
            var playerAmmo = playerDetailedFactory.CreateEvent(() => new AmmoEvent(27, 100, 1001, 3));
            Console.WriteLine($"  Ammo event #{playerAmmo.SequenceNumber} (tag {playerAmmo.Tag}): {((AmmoEvent)playerAmmo).Current}/{((AmmoEvent)playerAmmo).Maximum}");
            
            // Updated sequence number after adding more events
            Console.WriteLine($"\nUpdated player sequence (1001): {streamSequencer.GetCurrentSequence(1001)}");
        }
        
        // Custom event classes for demonstration
        
        [Serializable]
        private class HealthEvent : EventBase
        {
            public double CurrentHealth { get; }
            
            public HealthEvent(double health, int streamId, int tag) : base(streamId, tag)
            {
                CurrentHealth = health;
            }
        }
        
        [Serializable]
        private class AmmoEvent : EventBase
        {
            public int Current { get; }
            public int Maximum { get; }
            
            public AmmoEvent(int current, int maximum, int streamId, int tag) : base(streamId, tag)
            {
                Current = current;
                Maximum = maximum;
            }
        }
    }
}
```

## System.Numerics Integration Example

```csharp
// Copyright (c) 2025 Inovus. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Numerics;
using Inovus.Messaging;
using Inovus.Messaging.Events;
using Inovus.Messaging.Factories;
using Inovus.Messaging.Adapters;

namespace Inovus.Messaging.Examples
{
    /// <summary>
    /// Example demonstrating integration with System.Numerics
    /// </summary>
    public class NumericsIntegrationExample
    {
        public static void Run()
        {
            Console.WriteLine("=== System.Numerics Integration Example ===");
            
            // Create a factory for events
            var factory = new EventFactory(streamId: 501);
            
            // Create a 3D vector using System.Numerics
            Vector3 position = new Vector3(10.5f, 1.75f, 42.0f);
            Console.WriteLine($"Original Vector3: ({position.X}, {position.Y}, {position.Z})");
            
            // Convert to a Vector3DEvent
            Vector3DEvent positionEvent = position.ToVector3DEvent(streamId: 501, tag: 1);
            factory.AssignSequenceNumber(positionEvent);
            
            Console.WriteLine($"Converted to Vector3DEvent: #{positionEvent.SequenceNumber} in stream {positionEvent.StreamId}");
            Console.WriteLine($"  Coordinates: ({positionEvent.X}, {positionEvent.Y}, {positionEvent.Z})");
            
            // Create a sequenced event directly
            Vector3 cameraPosition = new Vector3(9.0f, 3.75f, 41.0f);
            Vector3DEvent cameraEvent = cameraPosition.ToSequencedEvent(factory, tag: 2);
            
            Console.WriteLine($"Camera Position Event: #{cameraEvent.SequenceNumber} (tag {cameraEvent.Tag})");
            Console.WriteLine($"  Coordinates: ({cameraEvent.X}, {cameraEvent.Y}, {cameraEvent.Z})");
            
            // Working with quaternions
            Console.WriteLine("\nQuaternion Example:");
            
            // Create a rotation using System.Numerics quaternion
            Quaternion rotation = Quaternion.CreateFromYawPitchRoll(0.5f, 0.0f, 0.0f); // Yaw 0.5 radians
            
            // Convert to RotationEvent
            RotationEvent rotationEvent = rotation.ToRotationEvent(streamId: 501, tag: 3);
            factory.AssignSequenceNumber(rotationEvent);
            
            Console.WriteLine($"Rotation Event: #{rotationEvent.SequenceNumber} (tag {rotationEvent.Tag})");
            Console.WriteLine($"  Angles (rad): X={rotationEvent.RotationX:F3}, Y={rotationEvent.RotationY:F3}, Z={rotationEvent.RotationZ:F3}");
            
            // Matrix example
            Console.WriteLine("\nMatrix Example:");
            
            // Create a transformation matrix
            Matrix4x4 transform = Matrix4x4.CreateFromYawPitchRoll(0.2f, 0.3f, 0.1f) * 
                                 Matrix4x4.CreateTranslation(5.0f, 1.0f, 8.0f);
            
            // Extract position and rotation as events
            (Vector3DEvent posEvent, RotationEvent rotEvent) = transform.ToEvents(streamId: 501, tag: 4);
            factory.AssignSequenceNumber(posEvent);
            factory.AssignSequenceNumber(rotEvent);
            
            Console.WriteLine($"Position from Matrix: #{posEvent.SequenceNumber}");
            Console.WriteLine($"  Coordinates: ({posEvent.X:F3}, {posEvent.Y:F3}, {posEvent.Z:F3})");
            Console.WriteLine($"Rotation from Matrix: #{rotEvent.SequenceNumber}");
            Console.WriteLine($"  Angles (rad): X={rotEvent.RotationX:F3}, Y={rotEvent.RotationY:F3}, Z={rotEvent.RotationZ:F3}");
            
            // Recreate matrix from events
            Matrix4x4 recreatedMatrix = Matrix4x4Extensions.CreateTransformMatrix(posEvent, rotEvent);
            
            // Extract position from recreated matrix
            Vector3 extractedPosition = recreatedMatrix.Translation;
            Console.WriteLine("\nRecreated Matrix Translation:");
            Console.WriteLine($"  ({extractedPosition.X:F3}, {extractedPosition.Y:F3}, {extractedPosition.Z:F3})");
            
            // Round-trip conversion
            Console.WriteLine("\nRound-trip Vector3 Conversion:");
            Vector3 roundTripVector = positionEvent.ToVector3();
            Console.WriteLine($"Original: ({position.X}, {position.Y}, {position.Z})");
            Console.WriteLine($"Round-trip: ({roundTripVector.X}, {roundTripVector.Y}, {roundTripVector.Z})");
        }
    }
}
```