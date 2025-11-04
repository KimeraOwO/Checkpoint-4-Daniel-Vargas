using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class SlowAura : MonoBehaviour
{
    [Range(0, 1)]
    public float slowFactor = 0.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            agent.speed *= slowFactor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            agent.speed /= slowFactor;
        }
    }
}