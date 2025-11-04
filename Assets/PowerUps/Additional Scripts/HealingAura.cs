using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HealingAura : MonoBehaviour
{
    public float healPerSecond = 5f;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.Heal(healPerSecond * Time.deltaTime);
        }
    }
}