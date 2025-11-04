using UnityEngine;

[CreateAssetMenu(fileName = "NaturalUp", menuName = "PowerUp Effects/NaturalUp")]
public class NaturalUpEffect : PowerUpEffect
{
    [Header("Configuración de Naturaleza")]
    public GameObject healingAuraPrefab;

    private GameObject currentAuraInstance;

    public override void Activate(GameObject player)
    {
        if (healingAuraPrefab != null)
        {
            currentAuraInstance = Instantiate(healingAuraPrefab, player.transform.position, player.transform.rotation, player.transform);
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