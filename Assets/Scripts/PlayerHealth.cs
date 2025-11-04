using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealth : MonoBehaviour
{
    [Header("Referencias")]
    private PlayerStats stats;

    [Header("Salud")]
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth <= 0) return;

        float reduction = stats.currentDamageReduction;
        float actualDamage = damageAmount * (1.0f - reduction);

        currentHealth -= actualDamage;

        Debug.Log($"Jugador recibió {actualDamage} de daño (reducido en {reduction * 100}%).");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
    }
}