using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    [Header("Configuración Base")]
    public string powerUpName;
    public float duration;

    [Header("VFX (Se asigna en el asset)")]
    public Material powerUpShader;
    public GameObject vfxParticlesPrefab;

    public abstract void Activate(GameObject player);

    public abstract void Deactivate(GameObject player);

    public virtual void OnUpdate(GameObject player) { }
}