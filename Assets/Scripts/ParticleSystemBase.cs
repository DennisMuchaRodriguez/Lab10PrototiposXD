using System.Collections.Generic;
using UnityEngine;

namespace ParticleSystemFlyweight
{
    public abstract class ParticleSystemBase : MonoBehaviour
    {
        [SerializeField] protected ParticleSettings settings;

        protected List<Particle> allParticles = new List<Particle>();
        protected List<Vector3> sharedPositions;
        protected List<Vector3> sharedVelocities;
        protected List<Vector3> sharedColors;

        protected abstract void Start();

        protected List<Vector3> GetSharedProperties(Vector2 range)
        {
            List<Vector3> properties = new List<Vector3>();

            for (int i = 0; i < settings.propertiesCount; i++)
            {
                properties.Add(new Vector3(
                    Random.Range(range.x, range.y),
                    Random.Range(range.x, range.y),
                    Random.Range(range.x, range.y)));
            }

            return properties;
        }

        protected Vector3 GetRandomColor()
        {
            return (Vector4)settings.colorGradient.Evaluate(Random.value);
        }
    }
}
