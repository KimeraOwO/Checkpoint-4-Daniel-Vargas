using UnityEngine;

[CreateAssetMenu(fileName = "InvisibilityUp", menuName = "PowerUp Effects/InvisibilityUp")]
public class InvisibilityUpEffect : PowerUpEffect
{
    private int invisibleLayer;

    public override void Activate(GameObject player)
    {
        invisibleLayer = LayerMask.NameToLayer("Invisible");

        player.layer = invisibleLayer;
    }

    public override void Deactivate(GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            player.layer = stats.baseLayer;
        }
    }
}