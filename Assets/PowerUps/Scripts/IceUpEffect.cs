using UnityEngine;

[CreateAssetMenu(fileName = "IceUp", menuName = "PowerUp Effects/IceUp")]
public class IceUpEffect : PowerUpEffect
{
    [Header("Configuración de Hielo")]
    public GameObject iceAuraPrefab;

    private GameObject currentAuraInstance;

    public override void Activate(GameObject player)
    {
        if (iceAuraPrefab != null)
        {
            currentAuraInstance = Instantiate(iceAuraPrefab, player.transform.position, player.transform.rotation, player.transform);
        }
    }

    public override void Deactivate(GameObject player)
    {
        if (currentAuraInstance != null)
        {
            Destroy(currentAuraInstance);
        }
    }
}