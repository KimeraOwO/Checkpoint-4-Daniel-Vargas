using UnityEngine;

[CreateAssetMenu(fileName = "NightVisionUp", menuName = "PowerUp Effects/NightVisionUp")]
public class NightVisionUpEffect : PowerUpEffect
{
    public override void Activate(GameObject player)
    {
        Debug.Log("Visión Nocturna ACTIVADA");
    }

    public override void Deactivate(GameObject player)
    {
        Debug.Log("Visión Nocturna DESACTIVADA");
    }
}