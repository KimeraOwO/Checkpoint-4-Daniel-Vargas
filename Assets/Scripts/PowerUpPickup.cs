using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public PowerUpEffect powerUpData;

    public float reappearTime = 10f;

    private Collider itemCollider;
    private MeshRenderer meshRenderer;
    void Start()
    {
        itemCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (itemCollider.enabled && other.CompareTag("Player"))
        {
            PlayerPowerUpManager manager = other.GetComponent<PlayerPowerUpManager>();
            if (manager != null)
            {
                manager.ApplyPowerUp(powerUpData);
                SetItemActive(false);
                Invoke(nameof(Reappear), reappearTime);
            }
        }
    }
    void Reappear() { SetItemActive(true); }
    void SetItemActive(bool active)
    {
        if (itemCollider) itemCollider.enabled = active;
        if (meshRenderer) meshRenderer.enabled = active;
    }
}