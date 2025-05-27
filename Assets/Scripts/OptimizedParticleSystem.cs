using UnityEngine;

namespace ParticleSystemFlyweight
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class OptimizedParticleSystem : ParticleFlyweight
    {
        private Mesh particleMesh;
        private Vector3[] vertices;
        private Color[] colors;
        private int[] triangles;
        private MaterialPropertyBlock materialProperties;

        protected override void Start()
        {
            base.Start();

            // Initialize mesh
            InitializeMesh();

            // Create particles
            for (int i = 0; i < settings.maxParticles; i++)
            {
                Particle particle = new Particle(settings)
                {
                    SharedPositions = sharedPositions,
                    SharedVelocities = sharedVelocities,
                    SharedColors = sharedColors
                };

                allParticles.Add(particle);
            }

            // Set material
            GetComponent<MeshRenderer>().material = settings.material;
            materialProperties = new MaterialPropertyBlock();
        }

        private void InitializeMesh()
        {
            particleMesh = new Mesh();
            GetComponent<MeshFilter>().mesh = particleMesh;

           
            vertices = new Vector3[settings.maxParticles * 4];
            colors = new Color[settings.maxParticles * 4];
            triangles = new int[settings.maxParticles * 6];

            
            for (int i = 0; i < settings.maxParticles; i++)
            {
                int vIndex = i * 4;
                int tIndex = i * 6;

                triangles[tIndex] = vIndex;
                triangles[tIndex + 1] = vIndex + 1;
                triangles[tIndex + 2] = vIndex + 2;
                triangles[tIndex + 3] = vIndex;
                triangles[tIndex + 4] = vIndex + 2;
                triangles[tIndex + 5] = vIndex + 3;
            }

            particleMesh.vertices = vertices;
            particleMesh.triangles = triangles;
            particleMesh.colors = colors;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

        
            for (int i = 0; i < allParticles.Count; i++)
            {
                var particle = allParticles[i];
                particle.UpdateParticle(deltaTime);

                if (particle.Lifetime <= 0)
                {
                  
                    allParticles[i] = new Particle(settings)
                    {
                        SharedPositions = sharedPositions,
                        SharedVelocities = sharedVelocities,
                        SharedColors = sharedColors
                    };
                    particle = allParticles[i];
                }

            
                UpdateParticleMesh(i, particle);
            }

       
            particleMesh.vertices = vertices;
            particleMesh.colors = colors;
            particleMesh.RecalculateBounds();

           
            var renderer = GetComponent<MeshRenderer>();
            renderer.GetPropertyBlock(materialProperties);
            materialProperties.SetFloat("_CurrentTime", Time.time);
            renderer.SetPropertyBlock(materialProperties);
        }

        private void UpdateParticleMesh(int index, Particle particle)
        {
            int vIndex = index * 4;
            float size = particle.Size;
            float normalizedLifetime = particle.GetNormalizedLifetime();

            // Get current properties
            Vector3 position = particle.Position; // Usamos la posición actualizada
            Vector3 colorVec = sharedColors[particle.CurrentPropertyIndex];
            Color color = new Color(colorVec.x, colorVec.y, colorVec.z, 1f - normalizedLifetime);

            // Update vertices for a quad
            vertices[vIndex] = position + new Vector3(-size, -size, 0);
            vertices[vIndex + 1] = position + new Vector3(-size, size, 0);
            vertices[vIndex + 2] = position + new Vector3(size, size, 0);
            vertices[vIndex + 3] = position + new Vector3(size, -size, 0);

            // Update colors
            colors[vIndex] = color;
            colors[vIndex + 1] = color;
            colors[vIndex + 2] = color;
            colors[vIndex + 3] = color;
        }
    }
}