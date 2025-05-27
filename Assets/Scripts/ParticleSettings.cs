using UnityEngine;

[CreateAssetMenu(fileName = "ParticleSettings", menuName = "Particles/New Particle Settings")]
public class ParticleSettings : ScriptableObject
{
    [Header("Rendering")]
    public Material material;

    [Header("Particle Properties")]
    [Range(100, 10000)]
    public int maxParticles = 1000;
    [Range(10, 100)]
    public int propertiesCount = 20;


    [Header("Lifetime")]
    [MinMaxRange(0.1f, 10f)]
    public Vector2 lifetimeRange = new Vector2(1f, 5f);

    [Header("Size")]
    [MinMaxRange(0.01f, 1f)]
    public Vector2 sizeRange = new Vector2(0.1f, 0.5f);

    [Header("Movement")]
    [MinMaxRange(-5f, 5f)]
    public Vector2 velocityRange = new Vector2(-1f, 1f);

    [Header("Colors")]
    public Gradient colorGradient;
}
public class MinMaxRangeAttribute : PropertyAttribute
{
    public readonly float min;
    public readonly float max;

    public MinMaxRangeAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}