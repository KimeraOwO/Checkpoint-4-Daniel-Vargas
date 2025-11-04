using UnityEngine;

[CreateAssetMenu(fileName = "JumpUp", menuName = "PowerUp Effects/JumpUp")]
public class JumpUpEffect : PowerUpEffect
{
    [Header("Configuración de Salto")]
    public float jumpMultiplier = 2f;

    public override void Activate(GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.ApplyJumpMultiplier(jumpMultiplier);
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