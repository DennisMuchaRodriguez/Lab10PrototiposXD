using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableParticleSystem
{
    [CreateAssetMenu(fileName ="ParticleSO", menuName ="Scriptable Objects/Particle System/Particle")]
    public class Particle : ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private Texture sprite;

        public Color Color => color;
        public Texture Sprite => sprite;

        public Vector3 Move(Vector3 position, Vector3 direction, float speed)
        {
            return position + direction * speed;
        }
    }
}