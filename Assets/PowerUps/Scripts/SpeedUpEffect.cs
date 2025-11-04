using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "PowerUp Effects/SpeedUp")]
public class SpeedUpEffect : PowerUpEffect
{
    [Header("Configuración de Velocidad")]
    public float speedMultiplier = 2f;

    public override void Activate(GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.ApplySpeedMultiplier(speedMultiplier);
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