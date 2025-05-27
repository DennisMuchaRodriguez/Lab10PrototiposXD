using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomParticleSystem
{
    public class MovingParticle : MonoBehaviour
    {
        private Particle particle;
        private Vector3 position;
        private Vector3 direction;
        private float speed;

        public void SetUp(Particle _particle, Vector3 _position, Vector3 _direction, float _speed)
        {
            particle = _particle;
            position = _position;
            direction = _direction;
            speed = _speed;

            Renderer _renderer = GetComponent<Renderer>();

            MaterialPropertyBlock _material = new MaterialPropertyBlock();

            _renderer.GetPropertyBlock(_material);
            _material.SetTexture("_MainTex", particle.Sprite);
            _material.SetColor("_Color", particle.Color);

            _renderer.SetPropertyBlock(_material);
        }

        private void Update()
        {
            position = particle.Move(position, direction, speed * Time.deltaTime);

            transform.position = position;
        }
    }
}
