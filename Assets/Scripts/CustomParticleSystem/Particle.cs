using UnityEngine;

namespace CustomParticleSystem
{
    [System.Serializable]
    public class Particle
    {
        private Color color;
        private Texture sprite;

        public Color Color => color;
        public Texture Sprite => sprite;

        public Particle(Color _color, Texture _sprite)
        {
            color = _color;
            sprite = _sprite;
        }

        public Vector3 Move(Vector3 position, Vector3 direction, float speed)
        {
            return position + direction * speed;
        }
    }
}
