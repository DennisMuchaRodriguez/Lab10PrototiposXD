using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleParticleSystem
{
    public class SimplePS : MonoBehaviour
    {
        [SerializeField] private Texture systemTexture;
        [SerializeField] private Color systemColor;

        [SerializeField] private int numberParticles;
        [SerializeField] private MovingParticle prefabParticle;

        private MovingParticle[] particles;

        private void Start()
        {
            particles = new MovingParticle[numberParticles];

            for (int i = 0; i < numberParticles; i++)
            {
                particles[i] = Instantiate(prefabParticle);
                particles[i].SetUp();
            }
        }

        private void Update()
        {
            for (int i = 0; i < numberParticles; i++)
            {
                particles[i].Move();
            }
        }
    }
}