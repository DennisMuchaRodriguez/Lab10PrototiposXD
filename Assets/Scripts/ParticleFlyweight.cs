using System.Collections.Generic;
using UnityEngine;

namespace ParticleSystemFlyweight
{
    public abstract class ParticleFlyweight : ParticleSystemBase
    {
        protected override void Start()
        {
            if (settings == null)
            {
                Debug.LogError("ParticleSettings not assigned!");
                return;
            }

      
            sharedPositions = GetSharedProperties(new Vector2(-5f, 5f)); 
            sharedVelocities = GetSharedProperties(settings.velocityRange);

            sharedColors = new List<Vector3>();
            for (int i = 0; i < settings.propertiesCount; i++)
            {
                sharedColors.Add(GetRandomColor());
            }
        }

    }
}