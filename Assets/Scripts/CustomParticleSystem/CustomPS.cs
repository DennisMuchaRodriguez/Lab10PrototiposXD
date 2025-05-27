using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomParticleSystem
{
    public class CustomPS : MonoBehaviour
    {
        [SerializeField] private Texture systemTexture;
        [SerializeField] private Color systemColor;

        [SerializeField] private int numberParticles;
        [SerializeField] private MovingParticle prefabParticle;

        private MovingParticle[] particles;
        private Particle _SystemParticle;

        private void Start()
        {
            _SystemParticle = new Particle(systemColor, systemTexture);

            particles = new MovingParticle[numberParticles];

            for (int i = 0; i < numberParticles; i++)
            {
                particles[i] = Instantiate(prefabParticle);
                particles[i].SetUp(_SystemParticle, transform.position, Vector3.up, 1f);
            }
        }
    }
}
