using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleParticleSystem
{
    public class MovingParticle : MonoBehaviour
    {
        [SerializeField] private Color color;
        [SerializeField] private Texture sprite;
        [SerializeField] private Vector3 position;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void SetUp()
        {
            _renderer.material.SetColor("_Color", color);
            _renderer.material.SetTexture("_MainTex", sprite);
        }

        public void Move()
        {
            position = Move(position, direction, speed * Time.deltaTime);

            transform.position = position;
        }

        public Vector3 Move(Vector3 position, Vector3 direction, float speed)
        {
            return position + direction * speed;
        }
    }
}