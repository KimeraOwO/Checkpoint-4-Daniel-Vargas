using UnityEngine;

[CreateAssetMenu(fileName = "DashUp", menuName = "PowerUp Effects/DashUp")]
public class DashUpEffect : PowerUpEffect
{
    [Header("Configuración de Dash")]
    public int newMaxCharges = 3;

    public override void Activate(GameObject player)
    {
        if (player.TryGetComponent<PlayerAbilities>(out PlayerAbilities abilities))
        {
            abilities.SetMaxCharges(newMaxCharges);
        }
    }

    public override void Deactivate(GameObject player)
    {
        if (player.TryGetComponent<PlayerAbilities>(out PlayerAbilities abilities))
        {
            abilities.ResetMaxCharges();
        }
    }
}