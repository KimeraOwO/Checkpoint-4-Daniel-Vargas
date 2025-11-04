using UnityEngine;

[CreateAssetMenu(fileName = "FireUp", menuName = "PowerUp Effects/FireUp")]
public class FireUpEffect : PowerUpEffect
{
    [Header("Configuración de Fuego")]
    public GameObject fireAuraPrefab;

    private GameObject currentAuraInstance;

    public override void Activate(GameObject player)
    {
        if (fireAuraPrefab != null)
        {
            currentAuraInstance = Instantiate(fireAuraPrefab, player.transform.position, player.transform.rotation, player.transform);
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