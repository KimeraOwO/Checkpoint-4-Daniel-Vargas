using UnityEngine;

[CreateAssetMenu(fileName = "ShieldUp", menuName = "PowerUp Effects/ShieldUp")]
public class ShieldUpEffect : PowerUpEffect
{
    [Header("Configuración de Escudo")]
    [Range(0, 1)]
    public float damageReduction = 0.7f;

    public override void Activate(GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.SetDamageReduction(damageReduction);
        }
    }

    public override void Deactivate(GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.ResetStats();
        }
    }
}