using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableParticleSystem
{
    public class CustomPS : MonoBehaviour
    {
        [SerializeField] private Particle SystemParticle;

        [SerializeField] private int numberParticles;
        [SerializeField] private MovingParticle prefabParticle;

        private MovingParticle[] particles;
        

        private void Start()
        {
            particles = new MovingParticle[numberParticles];

            for (int i = 0; i < numberParticles; i++)
            {
                particles[i] = Instantiate(prefabParticle);
                particles[i].SetUp(SystemParticle, transform.position, Vector3.up, 1f);
            }
        }
    }
}
