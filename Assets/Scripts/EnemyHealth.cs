using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Salud")]
    public float maxHealth = 50f;
    public float currentHealth;

    [Header("Lógica de Muerte y Respawn")]
    public GameObject deathVFXPrefab;
    public float respawnTime = 5.0f;

    private MeshRenderer meshRenderer;
    private Collider enemyCollider;
    private NavMeshAgent navAgent;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;

        meshRenderer = GetComponentInChildren<MeshRenderer>();
        enemyCollider = GetComponent<Collider>();
        navAgent = GetComponent<NavMeshAgent>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    private IEnumerator DieAndRespawn()
    {
        isDead = true;
        currentHealth = 0;

        if (navAgent != null) navAgent.enabled = false;
        if (enemyCollider != null) enemyCollider.enabled = false;

        float vfxDuration = 2.0f;
        if (deathVFXPrefab != null)
        {
            GameObject vfxInstance = Instantiate(deathVFXPrefab, transform.position, transform.rotation);

            if (vfxInstance.TryGetComponent<ParticleSystem>(out ParticleSystem ps))
            {
                vfxDuration = ps.main.duration;
            }
            Destroy(vfxInstance, vfxDuration);
        }

        yield return new WaitForSeconds(vfxDuration);

        if (meshRenderer != null) meshRenderer.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        if (meshRenderer != null) meshRenderer.enabled = true;
        if (navAgent != null) navAgent.enabled = true;
        if (enemyCollider != null) enemyCollider.enabled = true;

        currentHealth = maxHealth;
        isDead = false;
    }
}