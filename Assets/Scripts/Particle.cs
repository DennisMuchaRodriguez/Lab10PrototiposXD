using System.Collections.Generic;
using UnityEngine;

namespace ParticleSystemFlyweight
{
    public class Particle
    {
        // Intrinsic (shared) properties
        public List<Vector3> SharedPositions { get; set; }
        public List<Vector3> SharedVelocities { get; set; }
        public List<Vector3> SharedColors { get; set; }

        // Extrinsic (unique) properties
        public float Lifetime { get; private set; }
        public float MaxLifetime { get; private set; }
        public float Size { get; private set; }
        public int CurrentPropertyIndex { get; private set; }

        // Current position (unique to each particle)
        public Vector3 Position { get; private set; }

        public Particle(ParticleSettings settings)
        {
            MaxLifetime = Random.Range(settings.lifetimeRange.x, settings.lifetimeRange.y);
            Lifetime = MaxLifetime;
            Size = Random.Range(settings.sizeRange.x, settings.sizeRange.y);
            CurrentPropertyIndex = Random.Range(0, settings.propertiesCount - 1);
            Position = Vector3.zero; // Start at origin
        }

        public void UpdateParticle(float deltaTime)
        {
            Lifetime -= deltaTime;

            // Get current velocity and apply it to position
            Vector3 velocity = SharedVelocities[CurrentPropertyIndex];
            Position += velocity * deltaTime;

            // Cycle through properties
            CurrentPropertyIndex = (CurrentPropertyIndex + 1) % SharedPositions.Count;
        }

        public float GetNormalizedLifetime()
        {
            return 1f - (Lifetime / MaxLifetime);
        }
    }
}