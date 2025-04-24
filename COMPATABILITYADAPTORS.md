# System.Numerics Adapters

This document describes the adapter classes that provide integration with the System.Numerics library.

## Project Structure

```
EventStreaming/
├── Adapters/
│   └── SystemNumericsAdapters.cs
```

## SystemNumericsAdapters Implementation

The `SystemNumericsAdapters` class provides extension methods for converting between EventStreaming types and System.Numerics types:

```csharp
// Copyright © 2025 Mark Castle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Numerics;
using EventStreaming.Events;

namespace EventStreaming.Adapters
{
    /// <summary>
    /// Provides extension methods for converting between Vector3DEvent and System.Numerics.Vector3
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts a Vector3DEvent to a System.Numerics.Vector3
        /// </summary>
        /// <param name="vectorEvent">The vector event to convert</param>
        /// <returns>A System.Numerics.Vector3 with the same coordinates</returns>
        public static Vector3 ToVector3(this Vector3DEvent vectorEvent)
        {
            return new Vector3(
                (float)vectorEvent.X,
                (float)vectorEvent.Y,
                (float)vectorEvent.Z
            );
        }
        
        /// <summary>
        /// Creates a Vector3DEvent from a System.Numerics.Vector3
        /// </summary>
        /// <param name="vector">The source vector</param>
        /// <param name="streamId">Optional stream identifier (default: 0)</param>
        /// <param name="tag">Optional tag (default: 0)</param>
        /// <returns>A new Vector3DEvent with values from the System.Numerics.Vector3</returns>
        public static Vector3DEvent ToVector3DEvent(this Vector3 vector, int streamId = 0, int tag = 0)
        {
            return new Vector3DEvent(
                vector.X,
                vector.Y,
                vector.Z,
                streamId,
                tag
            );
        }
        
        /// <summary>
        /// Creates a sequenced Vector3DEvent from a System.Numerics.Vector3 using the factory
        /// </summary>
        /// <param name="vector">The source vector</param>
        /// <param name="factory">The event factory to use</param>
        /// <param name="streamId">Optional stream identifier (default: use factory default)</param>
        /// <param name="tag">Optional tag (default: use factory default)</param>
        /// <returns>A sequenced Vector3DEvent with values from the System.Numerics.Vector3</returns>
        public static Vector3DEvent ToSequencedEvent(this Vector3 vector, Factories.EventFactory factory, int? streamId = null, int? tag = null)
        {
            if (streamId.HasValue && tag.HasValue)
            {
                return factory.CreateVector3D(vector.X, vector.Y, vector.Z, streamId.Value, tag.Value);
            }
            else if (streamId.HasValue)
            {
                return factory.CreateVector3D(vector.X, vector.Y, vector.Z, streamId.Value);
            }
            else
            {
                return factory.CreateVector3D(vector.X, vector.Y, vector.Z);
            }
        }
    }
    
    /// <summary>
    /// Provides extension methods for converting between RotationEvent and System.Numerics.Quaternion
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Converts a RotationEvent to a System.Numerics.Quaternion
        /// </summary>
        /// <param name="rotationEvent">The rotation event to convert</param>
        /// <returns>A quaternion representing the rotation</returns>
        public static Quaternion ToQuaternion(this RotationEvent rotationEvent)
        {
            return Quaternion.CreateFromYawPitchRoll(
                (float)rotationEvent.RotationY,
                (float)rotationEvent.RotationX,
                (float)rotationEvent.RotationZ
            );
        }
        
        /// <summary>
        /// Creates a RotationEvent from a System.Numerics.Quaternion
        /// </summary>
        /// <param name="quaternion">The source quaternion</param>
        /// <param name="streamId">Optional stream identifier (default: 0)</param>
        /// <param name="tag">Optional tag (default: 0)</param>
        /// <returns>A new RotationEvent with values from the quaternion</returns>
        public static RotationEvent ToRotationEvent(this Quaternion quaternion, int streamId = 0, int tag = 0)
        {
            // Extract Euler angles (x=pitch, y=yaw, z=roll) from quaternion
            Vector3 eulerAngles = QuaternionToEulerAngles(quaternion);
            
            return new RotationEvent(
                eulerAngles.X,  // RotationX (pitch)
                eulerAngles.Y,  // RotationY (yaw)
                eulerAngles.Z,  // RotationZ (roll)
                streamId,
                tag
            );
        }
        
        /// <summary>
        /// Creates a sequenced RotationEvent from a System.Numerics.Quaternion using the factory
        /// </summary>
        /// <param name="quaternion">The source quaternion</param>
        /// <param name="factory">The event factory to use</param>
        /// <param name="streamId">Optional stream identifier (default: use factory default)</param>
        /// <param name="tag">Optional tag (default: use factory default)</param>
        /// <returns>A sequenced RotationEvent with values from the Quaternion</returns>
        public static RotationEvent ToSequencedEvent(this Quaternion quaternion, Factories.EventFactory factory, int? streamId = null, int? tag = null)
        {
            // Extract Euler angles from quaternion
            Vector3 eulerAngles = QuaternionToEulerAngles(quaternion);
            
            if (streamId.HasValue && tag.HasValue)
            {
                return factory.CreateRotation(eulerAngles.X, eulerAngles.Y, eulerAngles.Z, streamId.Value, tag.Value);
            }
            else if (streamId.HasValue)
            {
                return factory.CreateRotation(eulerAngles.X, eulerAngles.Y, eulerAngles.Z, streamId.Value);
            }
            else
            {
                return factory.CreateRotation(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);
            }
        }
        
        /// <summary>
        /// Converts a quaternion to Euler angles in radians
        /// </summary>
        /// <param name="q">The quaternion to convert</param>
        /// <returns>Vector3 containing (x=pitch, y=yaw, z=roll) in radians</returns>
        private static Vector3 QuaternionToEulerAngles(Quaternion q)
        {
            Vector3 angles;
            
            // Pitch (X-axis rotation)
            double sinp = 2.0 * (q.W * q.X + q.Y * q.Z);
            double cosp = 1.0 - 2.0 * (q.X * q.X + q.Y * q.Y);
            angles.X = (float)Math.Atan2(sinp, cosp);
            
            // Yaw (Y-axis rotation)
            double siny = 2.0 * (q.W * q.Y - q.Z * q.X);
            angles.Y = (float)(Math.Abs(siny) >= 1.0 
                ? Math.CopySign(Math.PI / 2.0, siny) 
                : Math.Asin(siny));
            
            // Roll (Z-axis rotation)
            double sinr = 2.0 * (q.W * q.Z + q.X * q.Y);
            double cosr = 1.0 - 2.0 * (q.Y * q.Y + q.Z * q.Z);
            angles.Z = (float)Math.Atan2(sinr, cosr);
            
            return angles;
        }
    }
    
    /// <summary>
    /// Provides extension methods for converting between Vector3DEvent/RotationEvent and System.Numerics.Matrix4x4
    /// </summary>
    public static class Matrix4x4Extensions
    {
        /// <summary>
        /// Creates a transformation matrix from position and rotation events
        /// </summary>
        /// <param name="position">The position vector event</param>
        /// <param name="rotation">The rotation event</param>
        /// <returns>A transformation matrix</returns>
        public static Matrix4x4 CreateTransformMatrix(Vector3DEvent position, RotationEvent rotation)
        {
            // Convert rotation to quaternion
            Quaternion quaternion = rotation.ToQuaternion();
            
            // Convert position to vector3
            Vector3 positionVector = position.ToVector3();
            
            // Create matrix
            return Matrix4x4.CreateFromQuaternion(quaternion) * 
                   Matrix4x4.CreateTranslation(positionVector);
        }
        
        /// <summary>
        /// Creates a transformation matrix from position and rotation
        /// </summary>
        /// <param name="position">The position vector</param>
        /// <param name="rotation">The rotation quaternion</param>
        /// <returns>A transformation matrix</returns>
        public static Matrix4x4 CreateTransformMatrix(Vector3 position, Quaternion rotation)
        {
            return Matrix4x4.CreateFromQuaternion(rotation) * 
                   Matrix4x4.CreateTranslation(position);
        }
        
        /// <summary>
        /// Extracts position and rotation from a transformation matrix to create events
        /// </summary>
        /// <param name="matrix">The transformation matrix</param>
        /// <param name="streamId">Optional stream identifier (default: 0)</param>
        /// <param name="tag">Optional tag (default: 0)</param>
        /// <returns>A tuple containing (Vector3DEvent position, RotationEvent rotation)</returns>
        public static (Vector3DEvent position, RotationEvent rotation) ToEvents(this Matrix4x4 matrix, int streamId = 0, int tag = 0)
        {
            // Decompose the matrix
            bool success = Matrix4x4.Decompose(matrix, out Vector3 scale, out Quaternion rotation, out Vector3 position);
            
            if (!success)
            {
                throw new InvalidOperationException("Unable to decompose the matrix into position and rotation.");
            }
            
            // Create events
            Vector3DEvent positionEvent = new Vector3DEvent(
                position.X,
                position.Y,
                position.Z,
                streamId,
                tag
            );
            
            RotationEvent rotationEvent = rotation.ToRotationEvent(streamId, tag);
            
            return (positionEvent, rotationEvent);
        }
        
        /// <summary>
        /// Extracts position from a transformation matrix
        /// </summary>
        /// <param name="matrix">The transformation matrix</param>
        /// <returns>The position vector</returns>
        public static Vector3 ExtractPosition(this Matrix4x4 matrix)
        {
            return matrix.Translation;
        }
        
        /// <summary>
        /// Extracts rotation from a transformation matrix
        /// </summary>
        /// <param name="matrix">The transformation matrix</param>
        /// <returns>The rotation quaternion</returns>
        public static Quaternion ExtractRotation(this Matrix4x4 matrix)
        {
            Matrix4x4.Decompose(matrix, out _, out Quaternion rotation, out _);
            return rotation;
        }
    }
}
```