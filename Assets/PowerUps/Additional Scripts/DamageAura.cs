using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageAura : MonoBehaviour
{
    public float damagePerSecond = 10f;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}